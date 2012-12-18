using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibServices
{
    /*
     * This class represents a book, it does mostly nothing, except inheriting from AbstractItem and it has an ISBN (International Standard Book Number)
     */
    public class Book : AbstractItem
    {
        public Book(string name, string author, DateTime printDate, ISBN isbn, string location) : base(name, author, printDate, isbn, location)
        {
            this.ISBN = isbn;
        }

        public ISBN ISBN { get; private set; }
    }
}
