using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPEditor
{
    public class LBUserData
    {

        public int ID { get; set; }
        public String Value { get; set; }   

        //Constructor
        public LBUserData(int id, String value)
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
