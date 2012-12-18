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
using BookLibLogics;
using BookLibServices;

namespace BookLibrary
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : UserControl
    {
        SearchTypeWindow stype;
        SearchResultsWindow sresults;
        ISNotify inotify;
        DynamicData dyndata;

        public SearchWindow()
        {
            InitializeComponent();
            stype = new SearchTypeWindow();
            inotify = new ISNotify(this);
            dyndata = DynamicData.Instance;
            dyndata.SearchWindowNotifier = inotify;
            sresults = new SearchResultsWindow();
            expanderContent.Content = sresults;
            sresults.EditActionInvoked += new EventHandler(sresults_EditActionInvoked);
        }

        void sresults_EditActionInvoked(object sender, EventArgs e)
        {
            expanderContent.Content = new editItemWindow(editItemWindow.editTypes.Edit, (AbstractItem)sender);
        }

        private void OptionsExpander_Expanded(object sender, RoutedEventArgs e)
        {
            expanderContent.Content = stype;
        }

        private void OptionsExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            expanderContent.Content = sresults;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["name"] = itemNameInp.Text != "" ? itemNameInp.Text : null;
            if (optionsExpander.IsExpanded)
            {
                parameters["serial"] = stype.SerialNumber != "" ? stype.SerialNumber : null;
                parameters["edition"] = stype.Edition != "" ? stype.Edition : null;
                parameters["author"] = stype.Author != "" ? stype.Author : null;
                parameters["dateFrom"] = stype.DateFrom != "" ? stype.DateFrom : null;
                parameters["dateTo"] = stype.DateTo != "" ? stype.DateTo : null;
                parameters["types"] = stype.CheckedTypes.Count > 0  && stype.CheckedTypes.ContainsValue(true) ? stype.CheckedTypes : null;
                parameters["subTypes"] = stype.CheckedSubtypes.Count > 0 && stype.CheckedSubtypes.ContainsValue(true) ? stype.CheckedSubtypes : null;
                parameters["categories"] = stype.CheckedCategories.Count > 0 && stype.CheckedCategories.ContainsValue(true) ? stype.CheckedCategories : null;
            }
            dyndata.Search(parameters);
        }
    }
    
    public class ISNotify : ISearchStatusNotifier
    {
        private SearchWindow activeWindow;
        public ISNotify(SearchWindow window)
        {
            activeWindow = window;
        }
        public void searchComplete(List<AbstractItem> items)
        {
            activeWindow.optionsExpander.IsExpanded = false;
        }
    }
}
