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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SelaResortBL;
using System.Xml.Serialization;
using System.IO;
using SelaResortUI.Properties;
using System.Configuration;
using SelaResortUI.Views;

namespace SelaResortUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ISetupForm> ucontrols;
        int currentControlNumber = 0;
        
        private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        internal T CreateInstance<T>(T type) where T : class, ISetupForm, new()
        {
            return new T();
        }
        delegate T SetupFormCreator<T>(T type) where T : class, ISetupForm, new();
        public MainWindow()
        {
            var firstRun = bool.Parse(config.AppSettings.Settings["FirstRun"].Value);
            InitializeComponent();
            if (firstRun)
            {
                backBtn.Visibility = Visibility.Hidden;
                ucontrols = new List<ISetupForm>
                {
                new WelcomeControl(),
                new AdminSetupControl(),
                new EmployeesSetupControl()
                };
                ccontrol.Content = ucontrols[currentControlNumber];
            }
            else
            {
                finishSetup(true);
            }
        }

        private void finishSetup(bool bypassParam = false)
        {
            if (bypassParam || ucontrols[currentControlNumber].TrySubmitChanges())
            {
                ResortWindow resort = new ResortWindow();
                resort.Show();
                config.AppSettings.Settings["FirstRun"].Value = "false";
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                this.Close();
            }
        }

        private void backBtn_Click_1(object sender, RoutedEventArgs e)
        {
            currentControlNumber--;
            ccontrol.Content = ucontrols[currentControlNumber];
            if (currentControlNumber == 0)
            {
                backBtn.Visibility = Visibility.Hidden;
            }
            if (currentControlNumber < ucontrols.Count - 1)
            {
                nextBtn.Visibility = Visibility.Visible;
                finishBtn.Visibility = Visibility.Hidden;
                cancelBtn.Visibility = Visibility.Visible;
            }
        }

        private void nextBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ucontrols[currentControlNumber].PreView();
            }
            catch (NotImplementedException)
            {
            }
            if (ucontrols[currentControlNumber].TrySubmitChanges())
            {
                currentControlNumber++;
                ccontrol.Content = ucontrols[currentControlNumber];
                if (currentControlNumber > 0)
                {
                    backBtn.Visibility = Visibility.Visible;
                }
                if (currentControlNumber == ucontrols.Count - 1)
                {
                    nextBtn.Visibility = Visibility.Hidden;
                    cancelBtn.Visibility = Visibility.Hidden;
                    finishBtn.Visibility = Visibility.Visible;
                }
            }
        }

        private void cancelBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel the setup?", "Setup Cancellation", MessageBoxButton.YesNo, MessageBoxImage.Stop);
            if (result == MessageBoxResult.Yes)
            {
                finishSetup();
            }
        }

        private void finishBtn_Click_1(object sender, RoutedEventArgs e)
        {
            finishSetup();
        }
    }
}
