using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SPEditor
{
    class SPFileItem : SPItem
    {
        private TextBox _tb;
        
        protected override Control GetControl()
        {
            return _tb;
        }

        override public void Make(Field f)
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
