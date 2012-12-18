using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    /*
     * The class represents a journal. Does nothing, inherits from AbstractItem and it has an ISSN (International Standard Serial Number)
     */
    public class Journal : AbstractItem
    {
        public Journal(string name, string author, string subject, DateTime printDate, ISSN issn, string location) : base(name, author, printDate, issn, location)
        {
            this.ISSN = issn;
            this.Subject = subject;
        }

        public ISSN ISSN { get; private set; }

        public string SerialNumber
        {
            get
            {
                return ISSN.Number;
            }
        }
        
        public string Subject { get; private set; }

    }
}
