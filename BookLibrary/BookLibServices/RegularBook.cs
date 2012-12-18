using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    [NameAttr(Desc="Regular Book")]
    public class RegularBook : Book
    {
        public enum Categories
        {
            [NameAttr(Desc = "Art & Design")]
            ArtDesign,
            AudioBook,
            Biography,
            Classic,
            Fiction,
            [NameAttr(Desc = "Science Fiction")]
            ScienceFiction,
            Travels
        }

        public RegularBook(string name, string author, DateTime printDate, ISBN isbn, Categories cat, string location) : base(name, author, printDate, isbn, location)
        {
            this.Category = cat;
        }

        public Categories Category { get; private set; }
    }
}
