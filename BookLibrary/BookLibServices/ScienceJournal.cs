using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    [NameAttr(Desc = "Science Journal")]
    public class ScienceJournal : Journal
    {
        public enum Categories
        {
            Psychology,
            Medicine,
            Biology,
            Physics,
            Chemistry,
            Engineering,
            [NameAttr(Desc = "Computer Sciences")]
            ComputerSciences,
            Philosophy
        }

        public ScienceJournal(string name, string author, string subject, DateTime printDate, ISSN issn, Categories cat, string location)
            : base(name, author, subject, printDate, issn, location)
        {
            this.Category = cat;
        }

        public Categories Category { get; private set; }
    }
}
