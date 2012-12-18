using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace BookLibServices
{
    /*
     * This is the base class of the project, AbstractItem, it is abstract and thus cannot be instantiated
     * Every item, whether it is a book or a journal, has at least a name, print date, category, identifying number and a number of copies that currently exist in the library
     * 
     */
    public abstract class AbstractItem
    {
        public AbstractItem(string name, string author, DateTime printDate, EAN ean, string location, int copies)
        {
            this.Name = name;
            this.PrintDate = printDate;
            this.Copies = copies;
            this.EANNUmber = ean;
            this.Location = location;
            this.Author = author;
        }

        public AbstractItem(string name, string author, DateTime printDate, EAN ean, string location) : this(name, author, printDate, ean, location, 1)
        {
        }

        public virtual void BorrowItem()
        {
            if (Copies > 0)
            {
                this.Copies--;
            }
            else
            {
                throw new OutOfStockException(string.Format("{0} is out of stock", this.Name));
            }
        }

        public void DepositItem()
        {
            this.Copies++;
        }
        [DisplayNameAttribute("ISBN/ISSN")]
        public EAN EANNUmber 
        {
            get;
            private set; 
        }
        public string Type { get { return this.GetType().ToString(); } }
        public string Name { get; private set; }
        public DateTime PrintDate { get; private set; }
        public int Copies { get; private set; }
        public string Location { get; private set; }
        public string Author { get; private set; }
    }
}
