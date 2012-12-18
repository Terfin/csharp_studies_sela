using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookLibServices;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BookLibrary
{
    /// <summary>
    /// Interaction logic for editItemWindow.xaml
    /// </summary>
    public partial class editItemWindow : UserControl
    {
        string selectedType;
        string selectedSubtype;
        SubTypes stypes = SubTypes.Instance;
        Categories cat = Categories.Instance;
        public enum editTypes
        {
            Add, Edit
        }

        public editItemWindow(editTypes edType, AbstractItem item = null)
        {
            InitializeComponent();
            
            List<Type> tlist = typeof(Book).Assembly.GetTypes().ToList<Type>();
            List<string> Types = new List<string>()
                {
                    "Book", "Journal"
                };
            Subtypes = new ObservableCollection<string>();
            typeCombo.ItemsSource = Types;
            typeCombo.DataContext = this;
            subTypeCombo.DataContext = this;
            if (edType == editTypes.Add)
            {
                saveButton.Visibility = System.Windows.Visibility.Hidden;
                addButton.Visibility = System.Windows.Visibility.Visible;
            }
            else if (edType == editTypes.Edit)
            {
                addButton.Visibility = System.Windows.Visibility.Hidden;
                saveButton.Visibility = System.Windows.Visibility.Visible;
                SearchObject sobj = getSearchObject(item);
                this.DataContext = sobj;
            }
        }

        private SearchObject getSearchObject(AbstractItem item)
        {
            SearchObject sobj = null;

            if (item is ChildrenBook)
            {
                ChildrenBook book = item as ChildrenBook;
                Dictionary<string, string> parameters = getParamsByBook(book);
                parameters["Category"] = book.Category.ToString();
                sobj = new SearchObject(parameters, book.PrintDate);
            }
            else if (item is RegularBook)
            {
                RegularBook book = item as RegularBook;
                Dictionary<string, string> parameters = getParamsByBook(book);
                parameters["Category"] = book.Category.ToString();
                this.DataContext = book;
            }
            else if (item is StudyBook)
            {
                StudyBook book = item as StudyBook;
                Dictionary<string, string> parameters = getParamsByBook(book);
                parameters["Category"] = book.Category.ToString();
                this.DataContext = book;
            }
            else if (item is RegularJournal)
            {
                RegularJournal journal = item as RegularJournal;
                Dictionary<string, string> parameters = getParamsByJournal(journal);
                parameters["Category"] = journal.Category.ToString();
                this.DataContext = journal;
            }
            else if (item is ScienceJournal)
            {
                ScienceJournal journal = item as ScienceJournal;
                Dictionary<string, string> parameters = getParamsByJournal(journal);
                parameters["Category"] = journal.Category.ToString();
                this.DataContext = journal;
            }
            return sobj;
        }

        private Dictionary<string, string> getParamsByJournal(Journal journal)
        {
            Dictionary<string, string> parameters = getParams(journal);
            parameters["Serial"] = journal.ISSN.Number;
            parameters["Type"] = "Journal";
            parameters["Subject"] = journal.Subject;
            return parameters;
        }

        private static Dictionary<string, string> getParamsByBook(Book book)
        {
            Dictionary<string, string> parameters = getParams(book);
            parameters["Serial"] = book.ISBN.Number;
            parameters["Type"] = "Book";
            return parameters;
        }

        private static Dictionary<string, string> getParams(AbstractItem item)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Name"] = item.Name;
            parameters["Author"] = item.Author;
            parameters["Subtype"] = item.GetType().Name;
            parameters["Author"] = item.Author;
            return parameters;
        }

        public string SelectedType 
        { 
            get
            {
                return selectedType;
            }
            set
            {
                selectedType = value;
                List<string> subtypes = stypes.getSubTypes(new List<string>()
                {
                    value.ToLower()
                });
                Subtypes.Clear();
                foreach (string subtype in subtypes)
                {
                    Subtypes.Add(subtype);
                }
            }
        }

        public string SelectedSubtype
        {
            get
            {
                return selectedSubtype;
            }
            set
            {
                selectedSubtype = value;
                List<string> categories = cat.getCategories(new List<string>()
                {
                    value.ToLower()
                }
            }
        }

        public ObservableCollection<string> Subtypes { get; private set; }
    }
}
