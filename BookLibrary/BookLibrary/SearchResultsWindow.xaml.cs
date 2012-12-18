﻿using System;
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
using System.Data;

namespace BookLibrary
{
    /// <summary>
    /// Interaction logic for SearchResultsWindow.xaml
    /// </summary>
    public partial class SearchResultsWindow : UserControl
    {
        internal DataTable table = new DataTable();
        private DynamicData dyn = DynamicData.Instance;
        internal event EventHandler EditActionInvoked;
        public SearchResultsWindow()
        {
            InitializeComponent();
            SRNotify resultsNotify = new SRNotify(this);
            dyn.ResultsWindowNotifier = resultsNotify;
            table.Columns.Add("ISSN|ISBN");
            table.Columns.Add("Name");
            table.Columns.Add("Author");
            table.Columns.Add("Type");
            table.Columns.Add("Subtype");
            table.Columns.Add("Category");
            table.Columns.Add("Publish Date");
            table.Columns.Add("Location");
            resultsGrid.DataContext = table;
        }

        private void resultsGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            addCustomColumn("Edit");
            addCustomColumn("Delete");
        }

        private void addCustomColumn(string columnName)
        {
            DataGridTemplateColumn dt = new DataGridTemplateColumn();
            dt.Header = columnName;
            FrameworkElementFactory editButton = new FrameworkElementFactory(typeof(Button), string.Format("{0}Button", columnName.ToLower()));
            editButton.SetValue(Button.ContentProperty, columnName);
            editButton.SetValue(Button.NameProperty, string.Format("{0}Button", columnName.ToLower()));
            editButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(delete_Click));
            DataTemplate cellTemplate = new DataTemplate();
            cellTemplate.VisualTree = editButton;
            dt.CellTemplate = cellTemplate;
            resultsGrid.Columns.Add(dt);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView datarv = ((FrameworkElement)sender).DataContext as DataRowView;
            DataRow dr = datarv.Row;
            if (((Button)sender).Name.Contains("edit"))
            {
                try 
	            {	        
                    this.EditActionInvoked(dyn.GetItemFromDataRow(dr), new EventArgs());
	            }
	            catch (Exception)
	            {
                    System.Windows.Forms.MessageBox.Show("Cannot load edit screen! Please report this bug!");
	            }
                
                
            }
            else if (((Button)sender).Name.Contains("delete"))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this item?", "Item Deletion", MessageBoxButton.YesNo,MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    dyn.RemoveItem(dr);
                    table.Rows.Remove(dr);
                }
            }
        }
    }

    public class SRNotify : ISearchStatusNotifier
    {
        private SearchResultsWindow activeWindow;
        public SRNotify(SearchResultsWindow window)
        {
            activeWindow = window;
        }
        public void searchComplete(List<AbstractItem> items)
        {
            activeWindow.table.Rows.Clear();
            if (items != null)
            {
                foreach (AbstractItem item in items)
                {
                    DataRow row = activeWindow.table.NewRow();
                    if (item.GetType() == typeof(ChildrenBook))
                    {
                        ChildrenBook book = item as ChildrenBook;
                        generateRowFromBook(book, row);
                        row["Category"] = book.Category;
                    }
                    if (item.GetType() == typeof(RegularBook))
                    {
                        RegularBook book = item as RegularBook;
                        generateRowFromBook(book, row);
                        row["Category"] = book.Category;
                    }
                    if (item.GetType() == typeof(StudyBook))
                    {
                        StudyBook book = item as StudyBook;
                        generateRowFromBook(book, row);
                        row["Category"] = book.Category;
                    }
                    if (item.GetType() == typeof(RegularJournal))
                    {
                        RegularJournal journal = item as RegularJournal;
                        generateRowFromJournal(journal, row);
                        row["Category"] = journal.Category;
                    }
                    if (item.GetType() == typeof(ScienceJournal))
                    {
                        ScienceJournal journal = item as ScienceJournal;
                        generateRowFromJournal(journal, row);
                        row["Category"] = journal.Category;
                    }
                    activeWindow.table.Rows.Add(row);
                }
            }
        }

        private void generateRowFromBook(Book book, DataRow row)
        {
            row["ISSN|ISBN"] = book.ISBN.Number;
            row["Name"] = book.Name;
            row["Author"] = book.Author;
            row["Type"] = typeof(Book).Name;
            row["Subtype"] = book.GetType().Name;
            row["Publish Date"] = book.PrintDate;
            row["Location"] = book.Location;
        }

        private void generateRowFromJournal(Journal journal, DataRow row)
        {
            row["ISSN|ISBN"] = journal.ISSN.Number;
            row["Name"] = journal.Name;
            row["Author"] = journal.Author;
            row["Type"] = typeof(Journal).Name;
            row["Subtype"] = journal.GetType().Name;
            row["Publish Date"] = journal.PrintDate;
            row["Location"] = journal.Location;
        }
    }
}
