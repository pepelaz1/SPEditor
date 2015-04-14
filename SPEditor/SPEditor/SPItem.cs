using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPItem
    {
        protected Field _f;

        protected String _value;
        public String Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public String Website { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public bool UseCurrentCredentials { get; set; }

        virtual protected Control GetControl()
        {
            return null;
        }

        virtual protected String GetValue()
        {
            return "";
        }
                    
        public Control Ctrl
        {
            get { return GetControl(); }
        }

        public void Save()
        {
            Value = GetValue();
        }

        virtual public void Make(Field f)
        {
            _f = f;
        }

        virtual public void SetPosition(int y)
        {
        }

        virtual public bool Validate(out String msg)
        {
            msg = "";
            String val = GetValue();
            if (_f.Required && (val == null || val == ""))
            {
                msg = "Field \"" + _f.Title + "\" can't be empty";
                return false;
            }
            return true;
        }

      //  virtual public String FormatValue()
      //  {
      // //     return GetValue();
      //  }

        virtual public void SetValue(ListItem item)
        {
           // item[_f.InternalName] = GetValue();
           item[_f.InternalName] = _value;
        }
    }
}

