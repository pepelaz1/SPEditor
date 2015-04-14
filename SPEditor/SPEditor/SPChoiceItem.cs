using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPChoiceItem : SPItem
    {
        private ComboBox _cb;

        protected override Control GetControl()
        {
            return _cb;
        }

        protected override String GetValue()
        {
            return (_cb != null) ? _cb.Text : null;
        }

        public override void Make(Field f)
        {
            base.Make(f);

            FieldChoice fc = _f as FieldChoice;

            _cb = new ComboBox();
            _cb.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (String s in fc.Choices)
               _cb.Items.Add(s);
     
            _cb.SelectedItem = fc.DefaultValue;
        }

        override public void SetPosition(int y)
        {
            _cb.Left = 110;
            _cb.Top = y;
            _cb.Width = 350;
            _cb.Height = 40;
        }
    }
}
