﻿namespace Todo.Forms
{
	partial class ListContactsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.contactsView = new System.Windows.Forms.TreeView();
			this.genderLabel = new System.Windows.Forms.Label();
			this.lastnameLabel = new System.Windows.Forms.Label();
			this.firstnameLabel = new System.Windows.Forms.Label();
			this.addressLabel = new System.Windows.Forms.Label();
			this.cityLabel = new System.Windows.Forms.Label();
			this.areacodeLabel = new System.Windows.Forms.Label();
			this.landlineLabel = new System.Windows.Forms.Label();
			this.mobileLabel = new System.Windows.Forms.Label();
			this.companyLabel = new System.Windows.Forms.Label();
			this.departmentLabel = new System.Windows.Forms.Label();
			this.privateRadioButton = new System.Windows.Forms.RadioButton();
			this.businessRadioButton = new System.Windows.Forms.RadioButton();
			this.genderComboBox = new System.Windows.Forms.ComboBox();
			this.lastnameTextBox = new System.Windows.Forms.TextBox();
			this.firstnameTextBox = new System.Windows.Forms.TextBox();
			this.addressTextBox = new System.Windows.Forms.TextBox();
			this.cityTextBox = new System.Windows.Forms.TextBox();
			this.areacodeTextBox = new System.Windows.Forms.TextBox();
			this.landlineTextBox = new System.Windows.Forms.TextBox();
			this.mobileTextBox = new System.Windows.Forms.TextBox();
			this.companyTextBox = new System.Windows.Forms.TextBox();
			this.departmentTextBox = new System.Windows.Forms.TextBox();
			this.changeContactButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// contactsView
			// 
			this.contactsView.Location = new System.Drawing.Point(13, 13);
			this.contactsView.Name = "contactsView";
			this.contactsView.Size = new System.Drawing.Size(271, 460);
			this.contactsView.TabIndex = 0;
			// 
			// genderLabel
			// 
			this.genderLabel.AutoSize = true;
			this.genderLabel.Location = new System.Drawing.Point(301, 13);
			this.genderLabel.Name = "genderLabel";
			this.genderLabel.Size = new System.Drawing.Size(41, 13);
			this.genderLabel.TabIndex = 1;
			this.genderLabel.Text = "Anrede";
			// 
			// lastnameLabel
			// 
			this.lastnameLabel.AutoSize = true;
			this.lastnameLabel.Location = new System.Drawing.Point(304, 44);
			this.lastnameLabel.Name = "lastnameLabel";
			this.lastnameLabel.Size = new System.Drawing.Size(35, 13);
			this.lastnameLabel.TabIndex = 2;
			this.lastnameLabel.Text = "Name";
			// 
			// firstnameLabel
			// 
			this.firstnameLabel.AutoSize = true;
			this.firstnameLabel.Location = new System.Drawing.Point(304, 74);
			this.firstnameLabel.Name = "firstnameLabel";
			this.firstnameLabel.Size = new System.Drawing.Size(49, 13);
			this.firstnameLabel.TabIndex = 3;
			this.firstnameLabel.Text = "Vorname";
			// 
			// addressLabel
			// 
			this.addressLabel.AutoSize = true;
			this.addressLabel.Location = new System.Drawing.Point(304, 109);
			this.addressLabel.Name = "addressLabel";
			this.addressLabel.Size = new System.Drawing.Size(42, 13);
			this.addressLabel.TabIndex = 4;
			this.addressLabel.Text = "Strasse";
			// 
			// cityLabel
			// 
			this.cityLabel.AutoSize = true;
			this.cityLabel.Location = new System.Drawing.Point(304, 150);
			this.cityLabel.Name = "cityLabel";
			this.cityLabel.Size = new System.Drawing.Size(21, 13);
			this.cityLabel.TabIndex = 5;
			this.cityLabel.Text = "Ort";
			// 
			// areacodeLabel
			// 
			this.areacodeLabel.AutoSize = true;
			this.areacodeLabel.Location = new System.Drawing.Point(304, 197);
			this.areacodeLabel.Name = "areacodeLabel";
			this.areacodeLabel.Size = new System.Drawing.Size(60, 13);
			this.areacodeLabel.TabIndex = 6;
			this.areacodeLabel.Text = "Postleitzahl";
			// 
			// landlineLabel
			// 
			this.landlineLabel.AutoSize = true;
			this.landlineLabel.Location = new System.Drawing.Point(301, 284);
			this.landlineLabel.Name = "landlineLabel";
			this.landlineLabel.Size = new System.Drawing.Size(43, 13);
			this.landlineLabel.TabIndex = 7;
			this.landlineLabel.Text = "Telefon";
			// 
			// mobileLabel
			// 
			this.mobileLabel.AutoSize = true;
			this.mobileLabel.Location = new System.Drawing.Point(301, 332);
			this.mobileLabel.Name = "mobileLabel";
			this.mobileLabel.Size = new System.Drawing.Size(32, 13);
			this.mobileLabel.TabIndex = 8;
			this.mobileLabel.Text = "Mobil";
			// 
			// companyLabel
			// 
			this.companyLabel.AutoSize = true;
			this.companyLabel.Location = new System.Drawing.Point(301, 376);
			this.companyLabel.Name = "companyLabel";
			this.companyLabel.Size = new System.Drawing.Size(32, 13);
			this.companyLabel.TabIndex = 9;
			this.companyLabel.Text = "Firma";
			// 
			// departmentLabel
			// 
			this.departmentLabel.AutoSize = true;
			this.departmentLabel.Location = new System.Drawing.Point(301, 427);
			this.departmentLabel.Name = "departmentLabel";
			this.departmentLabel.Size = new System.Drawing.Size(51, 13);
			this.departmentLabel.TabIndex = 10;
			this.departmentLabel.Text = "Abteilung";
			// 
			// privateRadioButton
			// 
			this.privateRadioButton.AutoSize = true;
			this.privateRadioButton.Location = new System.Drawing.Point(304, 244);
			this.privateRadioButton.Name = "privateRadioButton";
			this.privateRadioButton.Size = new System.Drawing.Size(51, 17);
			this.privateRadioButton.TabIndex = 11;
			this.privateRadioButton.TabStop = true;
			this.privateRadioButton.Text = "privat";
			this.privateRadioButton.UseVisualStyleBackColor = true;
			// 
			// businessRadioButton
			// 
			this.businessRadioButton.AutoSize = true;
			this.businessRadioButton.Location = new System.Drawing.Point(458, 244);
			this.businessRadioButton.Name = "businessRadioButton";
			this.businessRadioButton.Size = new System.Drawing.Size(79, 17);
			this.businessRadioButton.TabIndex = 12;
			this.businessRadioButton.TabStop = true;
			this.businessRadioButton.Text = "geschätlich";
			this.businessRadioButton.UseVisualStyleBackColor = true;
			// 
			// genderComboBox
			// 
			this.genderComboBox.FormattingEnabled = true;
			this.genderComboBox.Location = new System.Drawing.Point(428, 13);
			this.genderComboBox.Name = "genderComboBox";
			this.genderComboBox.Size = new System.Drawing.Size(121, 21);
			this.genderComboBox.TabIndex = 13;
			// 
			// lastnameTextBox
			// 
			this.lastnameTextBox.Location = new System.Drawing.Point(428, 36);
			this.lastnameTextBox.Name = "lastnameTextBox";
			this.lastnameTextBox.Size = new System.Drawing.Size(100, 20);
			this.lastnameTextBox.TabIndex = 14;
			// 
			// firstnameTextBox
			// 
			this.firstnameTextBox.Location = new System.Drawing.Point(428, 66);
			this.firstnameTextBox.Name = "firstnameTextBox";
			this.firstnameTextBox.Size = new System.Drawing.Size(100, 20);
			this.firstnameTextBox.TabIndex = 15;
			// 
			// addressTextBox
			// 
			this.addressTextBox.Location = new System.Drawing.Point(428, 101);
			this.addressTextBox.Name = "addressTextBox";
			this.addressTextBox.Size = new System.Drawing.Size(100, 20);
			this.addressTextBox.TabIndex = 16;
			// 
			// cityTextBox
			// 
			this.cityTextBox.Location = new System.Drawing.Point(428, 142);
			this.cityTextBox.Name = "cityTextBox";
			this.cityTextBox.Size = new System.Drawing.Size(100, 20);
			this.cityTextBox.TabIndex = 17;
			// 
			// areacodeTextBox
			// 
			this.areacodeTextBox.Location = new System.Drawing.Point(428, 189);
			this.areacodeTextBox.Name = "areacodeTextBox";
			this.areacodeTextBox.Size = new System.Drawing.Size(100, 20);
			this.areacodeTextBox.TabIndex = 18;
			// 
			// landlineTextBox
			// 
			this.landlineTextBox.Location = new System.Drawing.Point(428, 276);
			this.landlineTextBox.Name = "landlineTextBox";
			this.landlineTextBox.Size = new System.Drawing.Size(100, 20);
			this.landlineTextBox.TabIndex = 19;
			// 
			// mobileTextBox
			// 
			this.mobileTextBox.Location = new System.Drawing.Point(428, 324);
			this.mobileTextBox.Name = "mobileTextBox";
			this.mobileTextBox.Size = new System.Drawing.Size(100, 20);
			this.mobileTextBox.TabIndex = 20;
			// 
			// companyTextBox
			// 
			this.companyTextBox.Location = new System.Drawing.Point(428, 368);
			this.companyTextBox.Name = "companyTextBox";
			this.companyTextBox.Size = new System.Drawing.Size(100, 20);
			this.companyTextBox.TabIndex = 21;
			// 
			// departmentTextBox
			// 
			this.departmentTextBox.Location = new System.Drawing.Point(428, 419);
			this.departmentTextBox.Name = "departmentTextBox";
			this.departmentTextBox.Size = new System.Drawing.Size(100, 20);
			this.departmentTextBox.TabIndex = 22;
			// 
			// changeContactButton
			// 
			this.changeContactButton.Location = new System.Drawing.Point(507, 476);
			this.changeContactButton.Name = "changeContactButton";
			this.changeContactButton.Size = new System.Drawing.Size(122, 23);
			this.changeContactButton.TabIndex = 23;
			this.changeContactButton.Text = "Änderung Speichern";
			this.changeContactButton.UseVisualStyleBackColor = true;
			// 
			// ListContactsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 537);
			this.Controls.Add(this.changeContactButton);
			this.Controls.Add(this.departmentTextBox);
			this.Controls.Add(this.companyTextBox);
			this.Controls.Add(this.mobileTextBox);
			this.Controls.Add(this.landlineTextBox);
			this.Controls.Add(this.areacodeTextBox);
			this.Controls.Add(this.cityTextBox);
			this.Controls.Add(this.addressTextBox);
			this.Controls.Add(this.firstnameTextBox);
			this.Controls.Add(this.lastnameTextBox);
			this.Controls.Add(this.genderComboBox);
			this.Controls.Add(this.businessRadioButton);
			this.Controls.Add(this.privateRadioButton);
			this.Controls.Add(this.departmentLabel);
			this.Controls.Add(this.companyLabel);
			this.Controls.Add(this.mobileLabel);
			this.Controls.Add(this.landlineLabel);
			this.Controls.Add(this.areacodeLabel);
			this.Controls.Add(this.cityLabel);
			this.Controls.Add(this.addressLabel);
			this.Controls.Add(this.firstnameLabel);
			this.Controls.Add(this.lastnameLabel);
			this.Controls.Add(this.genderLabel);
			this.Controls.Add(this.contactsView);
			this.Name = "ListContactsForm";
			this.Text = "Liste aller Kontakte";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView contactsView;
		private System.Windows.Forms.Label genderLabel;
		private System.Windows.Forms.Label lastnameLabel;
		private System.Windows.Forms.Label firstnameLabel;
		private System.Windows.Forms.Label addressLabel;
		private System.Windows.Forms.Label cityLabel;
		private System.Windows.Forms.Label areacodeLabel;
		private System.Windows.Forms.Label landlineLabel;
		private System.Windows.Forms.Label mobileLabel;
		private System.Windows.Forms.Label companyLabel;
		private System.Windows.Forms.Label departmentLabel;
		private System.Windows.Forms.RadioButton privateRadioButton;
		private System.Windows.Forms.RadioButton businessRadioButton;
		private System.Windows.Forms.ComboBox genderComboBox;
		private System.Windows.Forms.TextBox lastnameTextBox;
		private System.Windows.Forms.TextBox firstnameTextBox;
		private System.Windows.Forms.TextBox addressTextBox;
		private System.Windows.Forms.TextBox cityTextBox;
		private System.Windows.Forms.TextBox areacodeTextBox;
		private System.Windows.Forms.TextBox landlineTextBox;
		private System.Windows.Forms.TextBox mobileTextBox;
		private System.Windows.Forms.TextBox companyTextBox;
		private System.Windows.Forms.TextBox departmentTextBox;
		private System.Windows.Forms.Button changeContactButton;
	}
}