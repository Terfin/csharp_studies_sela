using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    [NameAttr(Desc = "Study Book")]
    public class StudyBook : Book
    {
        public enum Categories
        {
            Philosophy,
            Psychology,
            Biology,
            Biochemistry,
            Chemistry,
            Physics,
            Mathematics,
            Mechanics,
            [NameAttr(Desc = "Computer Sciences")]
            ComputerSciences
        }
        
        public StudyBook(string name, string author, DateTime printDate, ISBN isbn, Categories cat, string location)
            :base(name, author, printDate, isbn, location)
        {
            this.Category = cat;
        }

        public Categories Category { get; private set; }
    }
}
