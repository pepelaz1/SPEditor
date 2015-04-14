using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPEditor
{
    public partial class SPUserControl : UserControl
    {
        public String Website { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public bool UseCurrentCredentials { get; set; }
        public LBUserData SelectedUser { get; set; }

        public SPUserControl()
        {
            InitializeComponent();
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                tbUser.Text = "";
                SelectedUser = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SPUserSearchForm frm = new SPUserSearchForm();
            frm.Website = Website;
            frm.Username = Username;
            frm.Password = Password;
            frm.UseCurrentCredentials = UseCurrentCredentials;
            frm.ShowDialog();

            if (frm.SelectedUser != null)
            {
                SelectedUser = frm.SelectedUser;
                tbUser.Text = frm.SelectedUser.Value;
            }
        } 
    }
}
