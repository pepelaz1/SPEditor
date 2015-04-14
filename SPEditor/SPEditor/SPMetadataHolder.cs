using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPEditor
{
    class SPMetadataHolder
    {
        private Dictionary<String, SPContentItem> _contentItems = new Dictionary<String, SPContentItem>();
        public Dictionary<String, SPContentItem> ContentItems
        {
            get { return _contentItems; }
            set { _contentItems = value; }
        }
    }
}
