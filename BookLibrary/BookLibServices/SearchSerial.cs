using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    public class SearchSerial : EAN
    {
        public SearchSerial(string industryPrefix, string serial)
            :base(industryPrefix, serial)
        {
        }
    }
}
