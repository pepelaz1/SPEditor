using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPEditor
{
    class MetadataHolder
    {
        private Dictionary<String, SPItem> _items = new Dictionary<String, SPItem>();
        public Dictionary<String, SPItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
}
