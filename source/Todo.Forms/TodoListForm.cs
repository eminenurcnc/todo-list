﻿using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Todo.Business;
using Todo.Business.Repositories;

namespace Todo.Forms
{
    public partial class TodoListForm : Form
    {
        private Business.Repositories.TodoRepository _todorepo;
        private Business.Repositories.ContactRepository _contactRepository;
        private Business.Repositories.AppointmentRepository _appointmentRepository;

        private BindingSource bsContacts = new BindingSource();
        private BindingSource bsAssignedContacts = new BindingSource();

        private List<Contact> _assignedContacts = new List<Contact>();
        private List<Contact> _Contacts = new List<Contact>();

        private List<Business.Todo> _allTodos = new List<Business.Todo>();
        private List<Business.Appointment> _allAppointsments = new List<Business.Appointment>();


        public TodoListForm(Business.Repositories.TodoRepository _todorepo, Business.Repositories.ContactRepository _contactRepository, Business.Repositories.AppointmentRepository _appointmentRepository)
        {
            this._todorepo = _todorepo;
            this._contactRepository = _contactRepository;
            this._appointmentRepository = _appointmentRepository;
            InitializeComponent();
            InitializeFormElements();
            this.DoubleBuffered = true;
        }

        private void InitializeFormElements()
        {
            this.todoListTreeView.HideSelection = false;

            //Contact List
            _Contacts = _contactRepository.GetAll();
            
            this.endDatePicker.Format = DateTimePickerFormat.Custom;
            this.endDatePicker.CustomFormat =  "dd.MM.yyyy HH:mm";
           
            this.startDatePicker.Format = DateTimePickerFormat.Custom;
            this.startDatePicker.CustomFormat = "dd.MM.yyyy HH:mm";

            ContactsListBox.DisplayMember = "FullName";
            ContactsListBox.ValueMember = "ContactId";
            bsContacts.DataSource = _Contacts;
            ContactsListBox.DataSource = bsContacts;

            AssignedContactsListbox.DisplayMember = "FullName";
            AssignedContactsListbox.ValueMember = "ContactId";
            bsAssignedContacts.DataSource = _assignedContacts;
            AssignedContactsListbox.DataSource = bsAssignedContacts;

            // TODO Tree
            this.todoListTreeView.LabelEdit = true;
            TreeNode rootNode = new TreeNode("Root");
            rootNode.Tag = null;
            this.todoListTreeView.Nodes.Add(rootNode);
            _allTodos = _todorepo.GetAll();
            List<Business.Todo> orphantodos = _allTodos.Where(x => x.Parent == null).ToList();
            _allAppointsments = _appointmentRepository.GetAll().ToList();

            foreach (var todo in orphantodos)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = todo.Title;
                newNode.Tag = todo;
                rootNode.Nodes.Add(newNode);
                appendChilden(newNode);
            }
        }


        private void newTodoListButton_Click(object sender, EventArgs e)
        {
            if(todoListTreeView.SelectedNode.Tag is Appointment)
            {
                MessageBox.Show("Todo Liste kann nicht einem Termin untergeordnet werden", "Hinweis");
                return;
            }
            TreeNode node = this.todoListTreeView.SelectedNode;
            TreeNode newNode = new TreeNode("Neue Todoliste");
            Business.Todo todo = new Business.Todo();
            todo.Title = "Neue Todoliste";
            newNode.Tag = todo;
            this.todoListTreeView.SelectedNode.Nodes.Add(newNode);
            this.todoListTreeView.SelectedNode.Expand();
            newNode.BeginEdit();
        }

        private void newEntryButton_Click(object sender, EventArgs e)
        {
            Appointment app = getAppointmentFromForm();
            TreeNode node = this.todoListTreeView.SelectedNode;

            if(node.Tag is Business.Todo)
            {
                app.TodoEntry = (Business.Todo)node.Tag;
                _appointmentRepository.Save(app);
                TreeNode newNode = new TreeNode();
                newNode = setImageForAppointment(newNode, app);
                newNode.Text = app.Title;
                newNode.Tag = app;
                node.Nodes.Add(newNode);
            }
            else if(node.Tag is Appointment)
            {
				Appointment updatedAppointment = getAppointmentFromForm();
				updatedAppointment.AppointmentId = ((Appointment)node.Tag).AppointmentId;
				updatedAppointment.TodoEntry = ((Appointment)node.Tag).TodoEntry;
				_appointmentRepository.Update(updatedAppointment);
				this.todoListTreeView.SelectedNode.Text = updatedAppointment.Title;
				this.todoListTreeView.SelectedNode.Tag = updatedAppointment;
				this.todoListTreeView.SelectedNode = setImageForAppointment(this.todoListTreeView.SelectedNode, updatedAppointment);
				MessageBox.Show("Der Eintrag wurde erfolgreich aktualisiert!", "Hinweis");
            }
            else
	        {
                MessageBox.Show("Kein Baumelement ausgewählt", "Hinweis");
	        }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
			TreeNode node = this.todoListTreeView.SelectedNode;
			if (node.Tag is Business.Appointment)
			{
				Appointment app = (Appointment)node.Tag;
				_appointmentRepository.Delete(app);
                node.Remove();
			}
            if(node.Tag is Business.Todo)
            {
                if(node.Nodes.Count!=0)
                {
                    DialogResult yesNo = MessageBox.Show("Das Element hat unterteilte Elemente, die ebenfalls gelöscht werden. Fortfahren?",
                     "Warnung",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2);

                    if (yesNo == DialogResult.No)
                        return;
                }
                Business.Todo todo = (Business.Todo)node.Tag;
                DeleteRecursive(node);
               

                _todorepo.Delete(todo);
                node.Remove();
            }
        }

        private void DeleteRecursive(TreeNode node)
        {
            foreach(TreeNode childNode in node.Nodes)
            {
                if(childNode.Tag is Appointment)
                {
                    Appointment app = (Appointment)childNode.Tag;
                    _appointmentRepository.Delete(app);
                }
                else if (childNode.Tag is Business.Todo)
                {
                    DeleteRecursive(childNode);
                    Business.Todo todo = (Business.Todo)childNode.Tag;
                    _todorepo.Delete(todo);
                }
            }
        }

        private void right_button_Click(object sender, EventArgs e)
        {
            if (this.ContactsListBox.SelectedValue == null)
                return;

            switchero(_assignedContacts, _Contacts, _contactRepository.GetSingleById((UInt32)ContactsListBox.SelectedValue));
        }

        private void left_button_Click(object sender, EventArgs e)
        {
            if (AssignedContactsListbox.SelectedValue == null)
                return;

            switchero(_Contacts, _assignedContacts, _contactRepository.GetSingleById((UInt32)AssignedContactsListbox.SelectedValue));
        }

        private void switchero(List<Contact> target, List<Contact> source, Contact item)
        {
            target.Add(item);
            source.Remove(source.Single(x=>x.ContactId==item.ContactId));

            bsAssignedContacts.DataSource = _assignedContacts;
            bsContacts.DataSource = _Contacts;
            bsAssignedContacts.ResetBindings(false);
            bsContacts.ResetBindings(false);
        }

        private void After_Edit(object sender, NodeLabelEditEventArgs e)
        {
            this.BeginInvoke(new Action(() => afterAfter_Edit(e.Node)));
        }

        private void afterAfter_Edit(TreeNode node)
        {

            if (node.Tag is Business.Todo)
            {
                Business.Todo todo = new Business.Todo();
                todo.Title = node.Text;
                UInt32 id = todo.TodoId;
                Business.Todo parent = null;

                if (node.Parent != null && node.Parent.Tag is Business.Todo)
                {
                    parent = (Business.Todo)node.Parent.Tag;
                }
                todo.Parent = parent;
                if (id == 0)
                {
                    _todorepo.Save(todo);
                }
                else
                {
                    _todorepo.Update(todo);
                }
                node.Tag = todo;
            }
            else if (node.Tag is Appointment)
            {
                Appointment app = (Appointment)node.Tag;

                app.Title = node.Text;

                _appointmentRepository.Update(app);
            }

        }

        public void appendChilden(TreeNode node)
        {
            if (node.Tag is Business.Todo)
            {
                Business.Todo todo = (Business.Todo)node.Tag;
                List<Business.Todo> children = _allTodos.Where(x => x.Parent != null && x.Parent.TodoId == todo.TodoId).ToList();
                List<Appointment> childrenApps = _allAppointsments.Where(x => x.TodoEntry != null && x.TodoEntry.TodoId == todo.TodoId).ToList();

                foreach (var child in children)
                {
                    TreeNode childNode = new TreeNode(child.Title, 0, 0);
                    childNode.Text = child.Title;
                    childNode.Tag = child;
                    node.Nodes.Add(childNode);
                    appendChilden(childNode);
                }

                foreach (var child in childrenApps)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = child.Title;
                    childNode = setImageForAppointment(childNode, child);
                    childNode.Tag = child;
                    node.Nodes.Add(childNode);
                }

            }
            else if (node.Tag is Business.Appointment)
            {
                Appointment app = (Appointment)node.Tag;
                List<Appointment> children = _allAppointsments.Where(x => x.TodoEntry.TodoId == app.TodoEntry.TodoId).ToList();
                foreach (var child in children)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = child.Title;
                    childNode.Tag = child;
                    node.Nodes.Add(childNode);
                    node = setImageForAppointment(childNode, child);
                }
                return;
            }
        }


        private Appointment getAppointmentFromForm()
        {
            Appointment app = new Appointment();

            app.Contacts = this.AssignedContactsListbox.Items.Cast<Contact>().ToList();
            app.Title = this.titleTextBox.Text;
            app.StartDate = DateTime.Parse(startDatePicker.Text);
            app.EndDate = DateTime.Parse(endDatePicker.Text);
            app.Description = this.descriptionBox.Text;
            app.Priority = (int)this.priorityElement.Value;
            app.Done = this.doneCheckBox.Checked;
          
            return app;
        }

        private void setViewToAppointment(Appointment app)
        {
            _assignedContacts = _appointmentRepository.GetSingleById(app.AppointmentId).Contacts.ToList();
            bsAssignedContacts.DataSource = _assignedContacts;
            bsAssignedContacts.ResetBindings(false);


            List<Contact> allContacts = _contactRepository.GetAll();
            _Contacts = allContacts.Where(p => !_assignedContacts.Any(p2 => p2.ContactId == p.ContactId)).ToList();
            bsContacts.DataSource = _Contacts;
            bsContacts.ResetBindings(false);

            this.titleTextBox.Text = app.Title;
            startDatePicker.Text = app.StartDate.ToString();
            endDatePicker.Text = app.EndDate.ToString();
            descriptionBox.Text = app.Description;
            priorityElement.Value = app.Priority;
            doneCheckBox.Checked = app.Done;
        }

        private TreeNode setImageForAppointment(TreeNode node,Appointment app)
        {
            if (app.Done)
            {
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
            }
            else
            {
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
            }

            return node;
        }

        private void After_Select(object sender, TreeViewEventArgs e)
        {
            if (this.todoListTreeView.SelectedNode.Tag is Appointment)
			{
				setViewToAppointment((Appointment)this.todoListTreeView.SelectedNode.Tag);
				this.newEntryButton.Text = "Eintrag aktualisieren";
			}
			else
			{
                ResetInputForm();
				this.newEntryButton.Text = "Neuen Termin speichern";
			}
        }

        private void ResetInputForm()
        {
            this.titleTextBox.Text = String.Empty;
            this.priorityElement.Value = 0;
            this.descriptionBox.Text = String.Empty;
            this.doneCheckBox.Checked = false;
            this.endDatePicker.Value = DateTime.Now;
            this.startDatePicker.Value = DateTime.Now;
            initbindings();
        }

        public void initbindings()
        {
            _Contacts = _contactRepository.GetAll();
            bsContacts.DataSource= _Contacts;

            _assignedContacts = new List<Contact>();
            bsAssignedContacts.DataSource = _assignedContacts;

            bsContacts.ResetBindings(false);
            bsAssignedContacts.ResetBindings(false);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Verzeichnis zum Speichern auswählen";
            saveFileDialog.Filter = "Excel Datei|*.xlsx";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != String.Empty)
                saveExcelFile(saveFileDialog.FileName);
        }

        private void saveExcelFile(string file)
        {
            SLDocument sl = new SLDocument();
            List<Appointment> allAppointments = _appointmentRepository.GetAll();
            int y = 2;

            SLStyle style = sl.CreateStyle();
            style.FormatCode = "dd.MM.yyyy HH:mm";

            //Write Headers
            sl.SetCellValue(1, 1, "Titel");
            sl.SetCellValue(1, 2, "Beschreibung");
            sl.SetCellValue(1, 3, "Priorität");
            sl.SetCellValue(1, 4, "Beginn");
            sl.SetCellValue(1, 5, "Ende");
            sl.SetCellValue(1, 6, "Kontakte");



            foreach(var app in allAppointments)
            {
                sl.SetCellValue(y, 1, app.Title);
                sl.SetCellValue(y, 2, app.Description);
                sl.SetCellValue(y, 3, app.Priority);
                sl.SetCellValue(y, 4, app.StartDate);
                sl.SetCellStyle(y, 4, style);
                sl.SetCellValue(y, 5, app.EndDate);
                sl.SetCellStyle(y, 5, style);
                string contacts=String.Empty;

                foreach (var contact in app.Contacts)
                    contacts += contact.FullName + ';';
                sl.SetCellValue(y, 6,contacts);

                sl.AutoFitColumn(y, 4);
                sl.AutoFitColumn(y, 5);

                y++;
            }
            

            sl.SaveAs(file);

        }
    }
}
