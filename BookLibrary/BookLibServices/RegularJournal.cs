using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    [NameAttr(Desc = "Regular Journal")]
    public class RegularJournal : Journal
    {
        public enum Categories
        {
            [NameAttr(Desc = "Finance & Economy")]
            FinanceEconomy,
            Housekeeping,
            Fashion,
            Arts,
            Motor,
            NewsPaper,
            Celebrity
        }

        public RegularJournal(string name, string author, string subject, DateTime printDate, ISSN issn, Categories cat, string location)
            :base(name, author, subject, printDate, issn, location)
        {
            this.Category = cat;
        }

        public Categories Category { get; private set; }
    }
}
