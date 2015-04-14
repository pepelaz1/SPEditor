using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPTextItem : SPItem
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
    }
}
