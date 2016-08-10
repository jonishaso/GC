using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPTT_API
{
    public class StarGuestRequest
    {
        public string returnAddress
        {
            get;
            set;
        }
        
        public string radioAddress
        {
            get;
            set;
        }

        public string request
        {
            get;
            set;
        }

        public string subjectLine
        {
            get;
            set;
        }

        public string eventID
        {
            get;
            set;
        }
    }
}
