﻿using RemoteWork.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace RemoteWork.Managers
{
    public partial class Command_Manager : Form
    {
        RconfigContext context = new RconfigContext();

        public Command_Manager()
        {
            InitializeComponent();
            LoadData();
        }
        private async void LoadData()
        { 
            var queryCommands=await (from c in context.Commands
                              select c.Name).ToListAsync();

            listBoxCommands.DataSource = queryCommands;
        }

        private void addCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command_Edit frm = new Command_Edit();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void editCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                string category = listBoxCommands.SelectedItem.ToString();
                Command_Edit frm = new Command_Edit(category);
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void deleteCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
               // MessageBox.Show(listBoxCommands.SelectedItem.ToString());
                var queryCommand = (from c in context.Commands
                                   where c.Name == listBoxCommands.SelectedItem.ToString()
                                   select c).FirstOrDefault();
                if (queryCommand != null)
                {
                    context.Commands.Remove(queryCommand);
                    context.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}
