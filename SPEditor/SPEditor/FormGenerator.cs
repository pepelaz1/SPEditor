using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPEditor
{
    class FormGenerator
    {
        private int _yoff;

        private Panel _container;
        public Panel Container
        {
            get { return _container; }
            set { _container = value; }
        }

        public FormGenerator()
        {
            _yoff = 5;
        }


        public void Generate(FieldCollection col, SPContentItem ci)
        {
            _container.Controls.Clear();
            _yoff = 5;

            foreach (Field field in col)
            {
                if (!field.Hidden && !field.ReadOnlyField && field.InternalName != "ContentType")
                {
                    Label lbl = new Label();
                    lbl.Left = 5;
                    lbl.Top = _yoff;
                    lbl.Text = field.InternalName + (field.Required ? " *" : "");
                    lbl.Height = 40;
                    lbl.Width = 100;
                    _container.Controls.Add(lbl);

                    TextBox tb = new TextBox();
                    tb.Left = 110;
                    tb.Top = _yoff - 3;
                    tb.Width = 200;
                    tb.Height = 40;

                    if (!ci.Items.ContainsKey(field.InternalName))
                    {
                        SPItem item = new SPTextItem();
                        ci.Items[field.InternalName] = item;
                    }
                    SPTextItem ti = ci.Items[field.InternalName] as SPTextItem;
                    tb.Text = ti.Value;

                    _container.Controls.Add(tb);
                    lbl.Tag = tb;

                    _yoff += 45;
                }
            }
        }

        public void Save(SPContentItem ci)
        {
            foreach (Control ctrl in _container.Controls)
            {
                if (ctrl is Label)
                {
                    Label lbl = ctrl as Label;
                    TextBox tb = lbl.Tag as TextBox;

                    String title = lbl.Text.TrimEnd(" *".ToCharArray());
                    SPTextItem ti = ci.Items[title] as SPTextItem;

                    ti.Value = tb.Text;
                }
            }
        }
    }
}
