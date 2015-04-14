using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPEditor
{
    class SPFormGenerator
    {
        private int _yoff;

        private Panel _container;
        public Panel Container
        {
            get { return _container; }
            set { _container = value; }
        }

        public String Website { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public bool UseCurrentCredentials { get; set; }

        public SPFormGenerator()
        {
            _yoff = 5;
        }

        private Control  CreateSPItem(Field f, SPContentItem ci)
        {
            SPItem item;
            if (!ci.Items.ContainsKey(f.InternalName))
            {
                String classname = "SPEditor.SP" + f.TypeAsString + "Item";
                try
                {
                    item = Activator.CreateInstance(Type.GetType(classname)) as SPItem;
                }
                catch(Exception)
                {
                    item = Activator.CreateInstance(Type.GetType("SPEditor.SPTextItem")) as SPItem;
                }             
                item.Website = Website;
                item.Username = Username;
                item.Password = Password;
                item.UseCurrentCredentials = UseCurrentCredentials;
                item.Make(f);
                ci.Items[f.InternalName] = item;
            }            
            item = ci.Items[f.InternalName];
            item.SetPosition(_yoff);
            return item.Ctrl;
        }


        public void Generate(FieldCollection col, SPContentItem ci)
        {
            _container.Controls.Clear();
            _yoff = 5;

                        
            foreach (Field field in col)
            {
                if (!field.Hidden && !field.ReadOnlyField && field.InternalName != "ContentType"
                    && field.InternalName != "FileLeafRef")
                {
                    Label lbl = new Label();
                    lbl.Left = 5;
                    lbl.Top = _yoff+3;
                    lbl.Text = field.Title + (field.Required ? " *" : "");
                    lbl.Height = 20;
                    lbl.Width = 100;
                    _container.Controls.Add(lbl);

                    Control ctrl = CreateSPItem(field, ci);
                    _container.Controls.Add(ctrl);
                    ctrl.Tag = field.InternalName;
                    lbl.Tag = ctrl;
                    
                    _yoff += ctrl.Height + 10;
                }              
            }
        }

        public bool Validate(SPContentItem ci)
        {
            foreach (Control ctrl in _container.Controls)
            {
                if (ctrl is Label)
                {
                    Label lbl = ctrl as Label;
                    Control ctl = lbl.Tag as Control;
                    String title = ctl.Tag.ToString().TrimEnd(" *".ToCharArray());
                    SPItem item = ci.Items[title];
                    String msg;
                    if (!item.Validate(out msg))
                    {
                        MessageBox.Show(msg);
                        return false;
                    }
                }
            }
            return true;
        }

        public void Save(SPContentItem ci)
        {
            foreach (Control ctrl in _container.Controls)
            {
                if (ctrl is Label)
                {
                    Label lbl = ctrl as Label;
                    Control ctl = lbl.Tag as Control;
                    String title = ctl.Tag.ToString().TrimEnd(" *".ToCharArray());
                    SPItem item = ci.Items[title];
                    item.Save();
                }
            }
        }
    }
}
