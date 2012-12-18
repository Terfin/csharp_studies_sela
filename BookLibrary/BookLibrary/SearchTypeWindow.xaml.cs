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
using System.Collections.ObjectModel;
using System.Reflection;
using BookLibServices;
using BookLibLogics;

namespace BookLibrary
{
    /// <summary>
    /// Interaction logic for SearchTypeWindow.xaml
    /// </summary>
    public partial class SearchTypeWindow : UserControl
    {
        private SubTypes stypes = SubTypes.Instance;
        private Categories cat = Categories.Instance;
        private Dictionary<string, bool> checkedTypes = new Dictionary<string, bool>();
        private Dictionary<string, bool> checkedSubtypes = new Dictionary<string, bool>();
        private Dictionary<string, bool> checkedCategories = new Dictionary<string, bool>();
        private ObservableCollection<string> subtypes = new ObservableCollection<string>();
        private ObservableCollection<string> categories1 = new ObservableCollection<string>();
        private ObservableCollection<string> categories2 = new ObservableCollection<string>();
        private ObservableCollection<string> categories3 = new ObservableCollection<string>();
        private ObservableCollection<string> categories4 = new ObservableCollection<string>();

        public SearchTypeWindow()
        {
            InitializeComponent();
            itemSubTypeList.DataContext = subtypes;
            itemCategoriesList1.DataContext = categories1;
            itemCategoriesList2.DataContext = categories2;
            itemCategoriesList3.DataContext = categories3;
            itemCategoriesList4.DataContext = categories4;
            serialNumInp.DataContext = this;
            authorInp.DataContext = this;
            dateFromPicker.DataContext = this;
            dateToPicker.DataContext = this;
            itemEditionInp.DataContext = this;
        }

        public bool IsCheckBoxChecked
        {
            get
            {
                return (bool)GetValue(IsCheckBoxCheckedProperty);
            }
            set
            {
                SetValue(IsCheckBoxCheckedProperty, value);
            }
        }

        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
            DependencyProperty.Register("IsCheckBoxChecked", typeof(bool), typeof(SearchTypeWindow), new UIPropertyMetadata(false));

        private void type_Checked(object sender, RoutedEventArgs e)
        {
            checkedTypes[((CheckBox)sender).Content.ToString()] = true;
            updateSubtypes();
        }

        private void type_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedTypes[((CheckBox)sender).Content.ToString()] = false;
            updateSubtypes();
        }

        private void updateSubtypes()
        {
            subtypes.Clear();
            List<string> parames = new List<string>();
            if (checkedTypes.ContainsKey(itemTypeJournal.Content.ToString()) && checkedTypes[itemTypeJournal.Content.ToString()])
            {
                parames.Add("journal");
            }
            if (checkedTypes.ContainsKey(itemTypeBook.Content.ToString()) && checkedTypes[itemTypeBook.Content.ToString()])
            {
                parames.Add("book");
            }
            foreach (string subt in stypes.getSubTypes(parames))
            {
                subtypes.Add(subt);
            }
            foreach (string box in itemSubTypeList.Items)
            {
                if (checkedSubtypes.ContainsKey(box) && checkedSubtypes[box])
                {
                    itemSubTypeList.SelectedItems.Add(box);
                }
            }
        }

        private void subType_Checked(object sender, RoutedEventArgs e)
        {
            checkedSubtypes[((CheckBox)sender).Content.ToString()] = true;
            updateCategories();
        }

        private void subType_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedSubtypes[((CheckBox)sender).Content.ToString()] = false;
            updateCategories();
        }


        private void updateCategories()
        {
            categories1.Clear();
            categories2.Clear();
            categories3.Clear();
            List<string> parames = new List<string>();
            foreach (string box in checkedSubtypes.Keys)
            {
                if (checkedSubtypes[box])
                {
                    parames.Add(box.ToLower());
                }
            }
            foreach (string category in cat.getCategories(parames))
            {
                if (categories1.Count < 9)
                {
                    categories1.Add(category);
                }
                else if (categories1.Count >= 9 && categories2.Count < 9)
                {
                    categories2.Add(category);
                }
                else if (categories2.Count >= 9 && categories3.Count < 9)
                {
                    categories3.Add(category);
                }
                else if (categories3.Count >= 9 && categories4.Count < 9)
                {
                    categories4.Add(category);
                }
            }
        }

        private void category_Checked(object sender, RoutedEventArgs e)
        {
            checkedCategories[((CheckBox)sender).Content.ToString()] = true;
        }

        private void category_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedCategories[((CheckBox)sender).Content.ToString()] = false;
        }

        public Dictionary<string, bool> CheckedTypes
        {
            get
            {
                return checkedTypes;
            }
        }

        public Dictionary<string, bool> CheckedSubtypes
        {
            get
            {
                return checkedSubtypes;
            }
        }

        public Dictionary<string, bool> CheckedCategories
        {
            get
            {
                return checkedCategories;
            }
        }

        public string SerialNumber { get; set; }
        public string Author { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Edition { get; set; }

    }
}
