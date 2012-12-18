using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookLibServices;
using System.Globalization;
using System;

namespace BookLibDAL
{
    public class ItemCollection
    {
        private static ItemCollection instance;
        private List<AbstractItem> items;
        private ItemCollection()
        {
            items = new List<AbstractItem>()
                {
                    new ChildrenBook("foo", "bar", DateTime.ParseExact("22/11/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None), new ISBN("343523213"), ChildrenBook.Categories.Folklore, "B:22"),
                    new ScienceJournal("foo", "bar", "Molecules of the apocalypse", DateTime.ParseExact("22/11/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None), new ISSN("34352321", "00"), ScienceJournal.Categories.Chemistry, "B:22")
                };
        }

        public static ItemCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemCollection();
                }
                return instance;
            }
        }
        public void Add(AbstractItem item)
        {
            AbstractItem foundItem = items.Find(x => x.Name == item.Name);
            if (foundItem != null)
            {
                foundItem.DepositItem();
            }
            else
            {
                items.Add(item);
            }
        }

        public void Remove(AbstractItem item)
        {
            items.Remove(item);
        }

        public List<AbstractItem> Items
        {
            get
            {
                AbstractItem[] ReadOnlyItems = new AbstractItem[items.Count];
                items.CopyTo(ReadOnlyItems);
                return ReadOnlyItems.ToList<AbstractItem>();
            }
        }

        public List<AbstractItem> getItemsByAuthor(string author)
        {
            return items.FindAll(x => x.Author.ToLower().Contains(author.ToLower()));
        }

        public List<AbstractItem> this[List<EAN> eans]
        {
            get
            {
                List<AbstractItem> foundItems = new List<AbstractItem>();
                foreach (EAN serial in eans)
                {
                    string noCheckSerial = serial.EANNumber.Substring(0, serial.EANNumber.Length - 1);
                    List<AbstractItem> foundItemsPerSerial = items.Where<AbstractItem>(x => x.EANNUmber.EANNumber.Contains(noCheckSerial)).ToList<AbstractItem>();
                    foundItems.AddRange(foundItemsPerSerial);
                }
                return foundItems;
            }
        }

        public List<AbstractItem> this[string name]
        {
            get
            {
                return items.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
            }
        }

    }
}
