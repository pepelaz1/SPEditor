using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPEditor
{
    class CBLookupData
    {

        public String ID { get; set; }
        public String Value { get; set; }   

        //Constructor
        public CBLookupData(String id, String value)
        {
            ID = id;
            Value = value;
        }


        //Override ToString method
        public override string ToString()
        {
            return Value;
        }
    }
}
