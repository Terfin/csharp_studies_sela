using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    [NameAttr(Desc = "Children Book")]
    public class ChildrenBook : Book
    {
        public enum Categories
        {
            PictureBook,
            Poetry,
            Folklore,
            Fantasy,
            [NameAttr(Desc = "Science Fiction")]
            ScienceFiction,
            [NameAttr(Desc = "Real Fiction")]
            RealFiction,
            [NameAttr(Desc = "Historical Fiction")]
            HistoricalFiction,
            Biography,
            NonFiction
        }

        public ChildrenBook(string name, string author, DateTime printTime, ISBN isbn, Categories cat, string location)
            :base(name, author, printTime, isbn, location)
        {
            this.Category = cat;
        }

        public Categories Category { get; private set; }
    }
}
