using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Globalization;

namespace SPEditor
{
    class SPDateTimeItem : SPItem
    {
        private NullableDateTimePicker _ndtp;

        protected override Control GetControl()
        {
            return _ndtp;
        }

        protected override String GetValue()
        {
            return (_ndtp != null) ? _ndtp.Text : null;
        }

        public override void Make(Field f)
        {
            base.Make(f);

            _ndtp = new NullableDateTimePicker();
            _ndtp.Format = DateTimePickerFormat.Custom;
            _ndtp.CustomFormat = "MM/dd/yyyy HH:mm";
            _ndtp.Value = null;
        }

        override public void SetPosition(int y)
        {
            _ndtp.Left = 110;
            _ndtp.Top = y;
            _ndtp.Width = 350;
            _ndtp.Height = 40;
        }


        override public void SetValue(ListItem item)
        {
            //String value = GetValue();
            String value = _value;
            if (value != " " && !string.IsNullOrEmpty(value))
            {
                // Add timezone offset
                DateTime dt = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                int hours = TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours;
                dt = dt.AddHours(-hours);
                item[_f.InternalName] = dt.ToString("MM/dd/yyyy HH:mm");
            }
        }
    }
}
