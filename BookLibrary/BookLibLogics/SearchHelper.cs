using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookLibServices;
using BookLibDAL;

namespace BookLibLogics
{
    static class SearchHelper
    {
        private static ItemCollection collection = ItemCollection.Instance;
        
        public static List<AbstractItem> searchByName(List<AbstractItem> origin, string name)
        {
            origin = origin == null ? collection.Items : origin;
            return origin.FindAll(x => x.Name == name);
        }

        public static List<AbstractItem> searchByAuthor(List<AbstractItem> origin, string author)
        {
            origin = origin == null ? collection.Items : origin;
            return origin.FindAll(x => x.Author == author);
        }

        public static List<AbstractItem> searchByEdition(List<AbstractItem> origin, string edition)
        {
            origin = origin == null ? collection.Items : origin;
            return origin.FindAll(x => {
                if (x.GetType() == typeof(Journal) || x.GetType().IsSubclassOf(typeof(Journal)))
	            {
                    return (x as Journal).ISSN.Edition == edition;
                }
                else
	            {
                    return false;
	             }});
        }

        public static List<AbstractItem> searchByType(List<AbstractItem> origin, Dictionary<string, bool> types)
        {
            List<AbstractItem> postFiltered = new List<AbstractItem>();
            origin = origin == null ? collection.Items : origin;
            foreach (string type in types.Keys)
            {
                string fixedType = type.Replace(" ", string.Empty);
                postFiltered.AddRange(origin.FindAll(x =>
                {
                    if (types[type])
                    {
                        Type typa = Type.GetType(string.Format("BookLibServices.{0}, BookLibServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", fixedType));
                        Type xtype = x.GetType();
                        return xtype.IsSubclassOf(typa) || typa == xtype;
                    }
                    else
                    {
                        return false;
                    }
                }

                ));
            }
            return postFiltered;
        }

        public static List<AbstractItem> searchByCategory(List<AbstractItem> origin, Dictionary<string, bool> categories)
        {
            List<AbstractItem> postFiltered = new List<AbstractItem>();
            origin = origin == null ? collection.Items : origin;
            foreach (string category in categories.Keys)
            {
                if (categories[category])
                {
                    string fixedCategory = category.Replace("&", string.Empty);
                    fixedCategory = category.Replace(" ", string.Empty);
                    postFiltered.AddRange(origin.FindAll(x =>
                    {
                        if (x.GetType() == typeof(ChildrenBook))
                        {
                            ChildrenBook cb = x as ChildrenBook;
                            return cb.Category.ToString() == fixedCategory;
                        }
                        else if (x.GetType() == typeof(RegularBook))
                        {
                            RegularBook rb = x as RegularBook;
                            return rb.Category.ToString() == fixedCategory;
                        }
                        else if (x.GetType() == typeof(StudyBook))
                        {
                            StudyBook sb = x as StudyBook;
                            return sb.Category.ToString() == fixedCategory;
                        }
                        else if (x.GetType() == typeof(RegularJournal))
                        {
                            RegularJournal rj = x as RegularJournal;
                            return rj.Category.ToString() == fixedCategory;
                        }
                        else if (x.GetType() == typeof(ScienceJournal))
                        {
                            ScienceJournal sj = x as ScienceJournal;
                            return sj.Category.ToString() == fixedCategory;
                        }
                        else
                        {
                            return false;
                        }
                    }));
                }
            }
            return postFiltered;
        }

        public static List<AbstractItem> searchByDate(List<AbstractItem> origin, DateTime dateStart, DateTime dateEnd)
        {
            origin = origin == null ? collection.Items : origin;
            if (dateStart != DateTime.MinValue || dateEnd != DateTime.MinValue)
            {
                List<AbstractItem> postFiltered = new List<AbstractItem>();
                if (dateStart != DateTime.MinValue)
                {
                    postFiltered.AddRange(origin.FindAll(x =>
                        {
                            return x.PrintDate >= dateStart;
                        }));
                }
                if (dateEnd != DateTime.MinValue)
                {
                    if (postFiltered.Count > 0)
                    {
                        origin = postFiltered;
                    }
                    postFiltered = origin.FindAll(x =>
                        {
                            return x.PrintDate <= dateEnd;
                        });
                }
                return postFiltered;
            }
            else
            {
                return origin;
            }
        }
    }
}
