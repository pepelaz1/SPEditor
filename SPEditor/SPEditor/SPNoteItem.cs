using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPNoteItem : SPItem
    {
        private RichTextBox _rtb;

        protected override Control GetControl()
        {
            return _rtb;
        }

        protected override String GetValue()
        {
            return (_rtb != null) ? _rtb.Text : null;
        }

        public override void Make(Field f)
        {
            base.Make(f);

            _rtb = new RichTextBox();
            _rtb.Multiline = true; 
        }

        override public void SetPosition(int y)
        {
            _rtb.Left = 110;
            _rtb.Top = y;
            _rtb.Width = 350;
            _rtb.Height = 40;
        }
    }
}
