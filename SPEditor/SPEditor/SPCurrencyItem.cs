using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPCurrencyItem : SPItem
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
            double result;
            double.TryParse(val, out result);
            if (!double.TryParse(val, out result) && val != "")
            {
                msg = "Field \"" + _f.Title + "\" should contain number value";
                return false;
            }
            return true;
        }

        //override public String FormatValue()
        //{
        //    String value = GetValue();
        //    return value.Replace(',', '.');
        //}
        override public void SetValue(ListItem item)
        {
            //String value = GetValue();
             if (!string.IsNullOrEmpty(_value))
            {
                String value = _value;
                //  item[_f.InternalName] =  value.Replace(',', '.');
                item[_f.InternalName] = value;
            }
        }
    }
}
