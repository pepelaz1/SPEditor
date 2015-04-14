using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPEditor
{
    public class CBContentTypeItem
    {
        ContentType _contentType;

        //Constructor
        public CBContentTypeItem(ContentType contentType)
        {
            _contentType = contentType;
        }

        //Accessor
        public ContentType ContentType
        {
            get
            {
                return _contentType;
            }
        }

        //Override ToString method
        public override string ToString()
        {
            return _contentType.Name;
        }
    }
}
