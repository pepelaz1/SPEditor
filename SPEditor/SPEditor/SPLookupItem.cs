using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Net;

namespace SPEditor
{
    class SPLookupItem : SPItem
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

            FieldLookup fl = _f as FieldLookup;
  
            _cb = new ComboBox();
            _cb.DropDownStyle = ComboBoxStyle.DropDownList;

            using (ClientContext ctx = new ClientContext(Website))
            {
                NetworkCredential userCredentials = UseCurrentCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(Username, Password);
                ctx.Credentials = userCredentials;
                
                Web web = ctx.Web;
                List list = web.Lists.GetById(Guid.Parse(fl.LookupList));

                CamlQuery camlQuery = new CamlQuery();
                ListItemCollection collListItem = list.GetItems(camlQuery);
     
                String str = fl.LookupField;
                try
                {
                    ctx.Load(
                        collListItem,
                        items => items.Include(
                        item => item.Id,
                        item => item[str]));

                    ctx.ExecuteQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
                foreach (ListItem itm in collListItem)
                {
                    try
                    {
                        String s = "";
                        object o = itm[str];
                        if (o != null)
                            s = o.ToString();
                        CBLookupData ld = new CBLookupData(itm.Id.ToString(), s);
                        _cb.Items.Add(ld);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }      
            _cb.SelectedItem = fl.DefaultValue;
        }

        override public void SetPosition(int y)
        {
            _cb.Left = 110;
            _cb.Top = y;
            _cb.Width = 350;
            _cb.Height = 40;
        }

        //override public void SetValue(ListItem item)
        //{
        //    if (_cb.SelectedItem != null)
        //    {
        //        CBLookupData ld = _cb.SelectedItem as CBLookupData;
        //        FieldLookupValue flv = new FieldLookupValue();
        //        flv.LookupId = int.Parse(ld.ID);
        //        item[_f.InternalName] = flv;
        //    }
        //}

        override public void SetValue(ListItem item)
        {
            //  String value = GetValue().Replace(',', '.');
            if (!string.IsNullOrEmpty(_value))
            {
                //String value = _value.Replace(',', '.');
                FieldLookupValue flv = new FieldLookupValue();
                flv.LookupId = int.Parse(_value);
                item[_f.InternalName] = flv;
            }
        }

        public int GetLookupsCount()
        {
            return _cb.Items.Count;
        }

        public string GetLookup(int n)
        {
            CBLookupData ld = _cb.Items[n] as CBLookupData;
            return ld.ID.ToString() + ";" + ld.Value;
        }
    }
}
