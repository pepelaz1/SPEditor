using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;




namespace SPEditor
{
    public partial class SPUserSearchForm : System.Windows.Forms.Form
    {
        public SPUserSearchForm()
        {
            InitializeComponent();
        }
        public String Website { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public bool UseCurrentCredentials { get; set; }
        public LBUserData SelectedUser { get; set; }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
            using (ClientContext ctx = new ClientContext(Website))
            {
                try
                {
                    NetworkCredential userCredentials = UseCurrentCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(Username, Password);
                    ctx.Credentials = userCredentials;

                    GroupCollection groupCollection = ctx.Web.SiteGroups;
                    ctx.Load
                        (groupCollection,
                         groups => groups.Include(
                         group => group.Users));
                    ctx.ExecuteQuery();

                    foreach (Group group in groupCollection)
                    {
                        UserCollection userCollection = group.Users;
                        foreach (User user in userCollection)
                        {
                            if (user.Title.Contains(tbSearch.Text))
                            {
                                LBUserData lbd = new LBUserData(user.Id, user.Title);
                                lbResults.Items.Add(lbd);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedUser = lbResults.SelectedItem as LBUserData;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedUser = null;
            Close();
        }

        private void lbResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectedUser = lbResults.SelectedItem as LBUserData;
            Close();
        }
    }
}
