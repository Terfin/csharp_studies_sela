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
using Common;
using System.Dynamic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace SelaResortUI.Views
{
    /// <summary>
    /// Interaction logic for EmployeesSetupControl.xaml
    /// </summary>
    public partial class EmployeesSetupControl : UserControl, ISetupForm
    {
        // Dictionary<FormFields, string> formValues = new Dictionary<FormFields, string>();
        ResortLogics rl = new ResortLogics();
        EmployeeViewModel employeeViewModel;
        public EmployeesSetupControl()
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Employees = new ObservableCollection<CommonEmployee>();
            employeeViewModel.EmployeeObject = new CommonEmployee();
            this.DataContext = employeeViewModel;
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public bool TrySubmitChanges()
        {
            return true;
        }

        private bool checkFields()
        {
            bool valid = true;
            foreach (TextBox box in FindVisualChildren<TextBox>(empgrid))
            {
                if (!CheckTextBox(box))
                {
                    valid = false;
                }
            }
            if (positionCBox.SelectedItem == null)
            {
                valid = false;
                positionCBox.BorderBrush = Brushes.Red;
            }
            else
            {
                positionCBox.ClearValue(ComboBox.BorderBrushProperty);
            }
            if (sDateCalendar.SelectedDate == default(DateTime))
            {
                valid = false;
                sDateCalendar.BorderBrush = Brushes.Red;
            }
            else
            {
                sDateCalendar.ClearValue(Calendar.BorderBrushProperty);
            }
            return valid;
        }

        private bool CheckTextBox(TextBox box)
        {
            if (box.Text.Length == 0)
            {
                box.BorderBrush = Brushes.Red;
                return false;
            }
            box.ClearValue(TextBox.BorderBrushProperty);
            return true;
        }

        //private Dictionary<FormFields, string> GetFormFields()
        //{
            
        //    formValues[FormFields.FirstName] = fnameBox.Text;
        //    formValues[FormFields.LastName] = lnameBox.Text;
        //    formValues[FormFields.Email] = emailBox.Text;
        //    formValues[FormFields.EmailConfirm] = cfrmEmailBox.Text;
        //    formValues[FormFields.Position] = positionCBox.SelectedItem.ToString();
        //    formValues[FormFields.Password] = passwdBox.Text;
        //    formValues[FormFields.PasswordConfirm] = cfrmPasswdBox.Text;
        //    formValues[FormFields.StartDate] = sDateCalendar.SelectedDate.ToString();
        //    return formValues;
        //}

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (checkFields())
            //{
            //    Dictionary<FormFields, string> formValues = GetFormFields();
            //    string errorMsg;
            //    if (rl.Validate(ResortFuncBase.EmployeeValidate, formValues, out errorMsg))
            //    {
            //        if (!editBtn.IsEnabled)
            //        {
            //            editBtn.IsEnabled = true;
            //            deleteBtn.IsEnabled = true;
            //        }
            //        rl.Insert(ResortFuncBase.RegisterEmployee, formValues);
            //        empListBox.Items.Add(formValues[FormFields.FirstName] + ' ' + formValues[FormFields.LastName]);
            //    }
            //    else
            //    {
            //        errBlock.Text = errorMsg;
            //    }
            //}
            employeeViewModel.EmployeeObject.Password = passwdBox.Password;
            employeeViewModel.EmployeeObject.ConfirmPassword = cfrmPasswdBox.Password;
            //employeeViewModel.EmployeeObject.BirthDate = new DateTime(1900, 1, 1);
            employeeViewModel.Error = rl.AddEntity(employeeViewModel.EmployeeObject, ResortFuncBase.ValidateExists, ResortFuncBase.ValidateEmail, ResortFuncBase.ValidatePassword);
            employeeViewModel.Employees = new ObservableCollection<CommonEmployee>(rl.GetEntities<CommonEmployee>().Select(x =>
            {
                if (x.FirstName == null)
                {
                    x.FirstName = "Anonymous";
                }
                return x;
            }).ToList());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeViewModel.EmployeeObject = (CommonEmployee)empListBox.SelectedItem;
            employeeViewModel.InitialEmail = employeeViewModel.EmployeeObject.Email;
            employeeViewModel.InitialPassword = employeeViewModel.EmployeeObject.Password;
            employeeViewModel.IsEditing = true;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (empListBox.Items.Count == 0)
            {
                editBtn.IsEnabled = false;
                deleteBtn.IsEnabled = false;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeViewModel.IsEditing = false;
            bool validationNeeded = false;
            if (employeeViewModel.EmployeeObject.Email != null && employeeViewModel.EmployeeObject.Email != employeeViewModel.InitialEmail)
            {
                validationNeeded = true;
            }
            if (employeeViewModel.EmployeeObject.Password != null && employeeViewModel.EmployeeObject.Password != employeeViewModel.InitialPassword)
            {
                validationNeeded = true;
            }
            if (validationNeeded)
            {
                errBlock.Text = rl.UpdateEntity(employeeViewModel.EmployeeObject, ResortFuncBase.ValidateExists, ResortFuncBase.ValidateEmail, ResortFuncBase.ValidatePassword);
            }
            else
            {
                employeeViewModel.EmployeeObject.Email = employeeViewModel.InitialEmail;
                employeeViewModel.EmployeeObject.Password = employeeViewModel.InitialPassword;
                errBlock.Text = rl.UpdateEntity(employeeViewModel.EmployeeObject);
            }
            employeeViewModel.EmployeeObject = new CommonEmployee();
        }


        public void PreView()
        {
            employeeViewModel.Employees = new ObservableCollection<CommonEmployee>(rl.GetEntities<CommonEmployee>().Select(x =>
            {
                if (x.FirstName == null)
                {
                    x.FirstName = "Anonymous";
                }
                return x;
            }).ToList());
            var a = ConfigurationManager.AppSettings["Globals"];
            if (employeeViewModel.Employees.Count == 1)
            {
                
            }
            this.Content = employeeViewModel;
        }
    }
}
