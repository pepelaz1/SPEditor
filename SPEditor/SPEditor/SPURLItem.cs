using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Text.RegularExpressions;

namespace SPEditor
{
    class SPURLItem : SPItem
    {
        private TextBox _tb;

        protected override Control GetControl()
        {
            return _tb;
        }

        protected override String GetValue()
        {
            return (_tb != null) ? _tb.Text : null;
        }

        public override void Make(Field f)
        {
            base.Make(f);

            _tb = new TextBox();
            _tb.Text = "http://";
        }

        override public void SetPosition(int y)
        {
            _tb.Left = 110;
            _tb.Top = y;
            _tb.Width = 350;
            _tb.Height = 40;
        }

        override public bool Validate(out String msg)
        {
            if (!base.Validate(out msg))
                return false;

            msg = "";
            String val = GetValue();

            if (val == "http://")
                return true;
            
            Regex regx = new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);
            MatchCollection col = regx.Matches(val);
            if (col.Count == 0)
            {
                msg = "Field \"" + _f.Title + "\" should contain well-formed URL value";
                return false;
            }
            return true;
        }

        //override public String FormatValue()
        //{
        //    String value = GetValue();
        //    if (value == "http://")
        //        return "";
        //    return value;
        //}

        override public void SetValue(ListItem item)
        {
           // String value = GetValue();
            String value = _value;
            if (value != "http://")
            {
                FieldUrlValue url = new FieldUrlValue();
                url.Description = value;
                url.Url = value;
                item[_f.InternalName] = url; 
            }
        }
    }
}
