using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPBooleanItem : SPItem
    {
        private CheckBox _cb;

        protected override Control GetControl()
        {
            return _cb;
        }

        protected override String GetValue()
        {
           // return (_cb != null) ? _cb.Text : null;
            return _cb.Checked ? "True" : "False";
        }

        public override void Make(Field f)
        {
            base.Make(f);

            _cb = new CheckBox();
        }

        override public void SetPosition(int y)
        {
            _cb.Left = 110;
            _cb.Top = y;
        }
    }
}
