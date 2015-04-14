using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPUserItem : SPItem
    {
        private SPUserControl _uc;

        protected override Control GetControl()
        {
            return _uc;
        }

        protected override String GetValue()
        {
            return (_uc != null) ? _uc.Text : null;
        }

        public override void Make(Field f)
        {
            base.Make(f);

            _uc = new SPUserControl(); 
            _uc.Website = Website;
            _uc.Username = Username;
            _uc.Password = Password;
            _uc.UseCurrentCredentials = UseCurrentCredentials;
        }

        override public void SetPosition(int y)
        {
            _uc.Left = 110;
            _uc.Top = y;
            _uc.Width = 350;
            _uc.Height = 20;
        }

        override public void SetValue(ListItem item)
        {
         /*   if (_uc.SelectedUser != null)
            {
                FieldUserValue usr = new FieldUserValue();
                usr.LookupId = _uc.SelectedUser.ID;
                item[_f.InternalName] = usr;
            }*/
            if (string.IsNullOrEmpty(_value) == false && _value != "0;")
            {
                string[] parts = _value.Split(";".ToCharArray());
                FieldUserValue usr = new FieldUserValue();
                usr.LookupId = int.Parse(parts[0]);
                item[_f.InternalName] = usr;
            }
        }
    }
}
