using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Instances
{
    public class SubscriptionArgs : EventArgs
    {
        public SearchType SearchType { get; set; }
        public string Filter { get; set; }

        public SubscriptionArgs()
        {
        }

        public SubscriptionArgs(SearchType searchType, string filter)
        {
            SearchType = searchType;
            Filter = filter;
        }
    }
}
