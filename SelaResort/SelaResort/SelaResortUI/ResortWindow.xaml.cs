using SelaResortBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SelaResortUI
{
    /// <summary>
    /// Interaction logic for ResortWindow.xaml
    /// </summary>
    public partial class ResortWindow : Window
    {
        ResortLogics BL = new ResortLogics();
        List<string> strings = new List<string>()
        {
            "foo", "boo", "moo"
        };
        ListBoxItem selectedItem;
        public ResortWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter_1(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = Brushes.Aqua;
        }

        private void StackPanel_MouseLeave_1(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = Brushes.RoyalBlue;
        }

        /// <summary>
        /// Since our stackpanel is the one catching the click event and not the listboxitem itself,
        /// we have to get the listboxitem parent of this stackpanel, in order to use it for our needs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            StackPanel panel = sender as StackPanel;
            DependencyObject viewItem = panel;
            while (!(viewItem is ListBoxItem))
            {
                viewItem = VisualTreeHelper.GetParent(viewItem);
            }
            selectedItem = (ListBoxItem)viewItem;
            var context = selectedItem.DataContext;
         }
    }
}

