﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Todo.Business.Entities;


namespace Todo.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Todo.Business.Database.NhibernateInitalize init = new Business.Database.NhibernateInitalize();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
