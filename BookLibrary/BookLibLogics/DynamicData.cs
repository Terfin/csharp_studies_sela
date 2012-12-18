using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookLibDAL;
using BookLibServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;

namespace BookLibLogics
{
    public class DynamicData
    {
        private static DynamicData instance;
        ItemCollection coll = ItemCollection.Instance;
        public int foo = 0;
        ISearchStatusNotifier searchWindowNotifier;
        ISearchStatusNotifier resultsWindowNotifier;

        private DynamicData()
        {
        }

        public static DynamicData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DynamicData();
                }
                return instance;
            }
        }

        public ISearchStatusNotifier SearchWindowNotifier 
        {
            set
            {
                searchWindowNotifier = value;
            }
        }

        public ISearchStatusNotifier ResultsWindowNotifier
        {
            set
            {
                resultsWindowNotifier = value;
            }
        }

        public AbstractItem GetItemFromDataRow(DataRow row)
        {
            string rawSerial = row["ISSN|ISBN"].ToString();
            string typeString = row["Subtype"].ToString().Replace(" ", string.Empty);
            typeString = string.Format("BookLibServices.{0}, BookLibServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", typeString);
            Type type = Type.GetType(typeString);
            List<AbstractItem> results = SearchHelper.searchByType(null, new Dictionary<string, bool>()
            {
                {type.Name, true}
            });
            AbstractItem item = results.Find(x => x.EANNUmber.EANNumber.Contains(string.Concat(rawSerial.Take<char>(rawSerial.Length - 1))));
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new NullReferenceException(string.Format("Item with serial {0} does not exist", rawSerial));
            }
        }

        public void RemoveItem(DataRow row)
        {
            try
            {
                AbstractItem item = GetItemFromDataRow(row);
                coll.Remove(item);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            
        }


        public void Search(Dictionary<string, object> parameters)
        {
            List<AbstractItem> _results = null;
            string serial = parameters.ContainsKey("serial") && parameters["serial"] != null ? (string)parameters["serial"] : null;
            string edition = parameters.ContainsKey("edition") && parameters["edition"] != null ? (string)parameters["edition"] : null;
            string name = parameters.ContainsKey("name") && (string)parameters["name"] != null ? (string)parameters["name"] : null;
            string author = parameters.ContainsKey("author") && (string)parameters["author"] != null ? (string)parameters["author"] : null;
            Dictionary<string, bool> types = parameters.ContainsKey("types") && parameters["types"] != null ? (Dictionary<string, bool>)parameters["types"] : null;
            Dictionary<string, bool> subTypes = parameters.ContainsKey("subTypes") && parameters["subTypes"] != null ? (Dictionary<string, bool>)parameters["subTypes"] : null;
            Dictionary<string, bool> categories = parameters.ContainsKey("categories") && parameters["categories"] != null ? (Dictionary<string, bool>)parameters["categories"] : null;
            DateTime dateFrom = DateTime.MinValue;
            if (parameters.ContainsKey("dateFrom") && DateTime.TryParse((string)parameters["dateFrom"], out dateFrom))
            {
            }
            DateTime dateTo = DateTime.MinValue;
            if (parameters.ContainsKey("dateTo") && DateTime.TryParse((string)parameters["dateTo"], out dateTo))
            {
            }

            if (serial != null)
            {
                List<EAN> serialNumbers = new List<EAN>();
                if (types != null)
                {
                    if (types.ContainsKey("Journal") && types["Journal"])
                    {
                        serialNumbers.Add(new SearchSerial(ISSN.IndustryPrefix, serial));
                    }
                    if (types.ContainsKey("Book") && types["Book"])
                    {
                        serialNumbers.Add(new SearchSerial(ISBN.IndustryPrefix, serial));
                    }
                }
                else
                {
                    serialNumbers.Add(new SearchSerial(ISSN.IndustryPrefix, serial));
                    serialNumbers.Add(new SearchSerial(ISBN.IndustryPrefix, serial));
                }
                _results = coll[serialNumbers];
            }
            if (name != null)
            {
                if (_results == null)
                {
                    _results = coll[name];
                }
                else
                {
                    _results = SearchHelper.searchByName(_results, name);
                }
            }
            if (author != null)
            {
                if (_results == null)
                {
                    _results = coll.getItemsByAuthor(author);
                }
                else
                {
                    _results = SearchHelper.searchByAuthor(_results, author);
                }
            }


            if (edition != null)
            {
                if (_results != null)
                {
                    _results = SearchHelper.searchByEdition(_results, edition);
                }
            }

            _results = types != null ? SearchHelper.searchByType(_results, types) : _results;
            _results = subTypes != null ? SearchHelper.searchByType(_results, subTypes) : _results;
            _results = categories != null ? SearchHelper.searchByCategory(_results, categories) : _results;
            _results = SearchHelper.searchByDate(_results, dateFrom, dateTo);
            resultsWindowNotifier.searchComplete(_results);
            searchWindowNotifier.searchComplete(_results);
        }
        
    }
}
