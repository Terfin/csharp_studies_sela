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

namespace SelaResortUI.Views
{
    /// <summary>
    /// Interaction logic for AdminSetupControl.xaml
    /// </summary>
    public partial class AdminSetupControl : UserControl, ISetupForm
    {
        ResortLogics rl;
        CommonEmployee admin = new CommonEmployee();
        public AdminSetupControl()
        {
            rl = new ResortLogics();
            InitializeComponent();
            this.DataContext = admin;
        }

        public bool TrySubmitChanges()
        {
            bool valid = true;
            if (emailBox.Text.Length == 0)
            {
                valid = false;
                emailBox.BorderBrush = Brushes.Red;
            }
            else
            {
                emailBox.ClearValue(TextBox.BorderBrushProperty);
            }
            if (emailCnfrmBox.Text.Length == 0)
            {
                valid = false;
                emailCnfrmBox.BorderBrush = Brushes.Red;
            }
            else
            {
                emailCnfrmBox.ClearValue(TextBox.BorderBrushProperty);
            }
            if (passwdBox.Password.Length == 0)
            {
                valid = false;
                passwdBox.BorderBrush = Brushes.Red;
            }
            else
            {
                passwdBox.ClearValue(TextBox.BorderBrushProperty);
            }
            if (passwdcnfrmBox.Password.Length == 0 || passwdcnfrmBox.Password != passwdBox.Password)
            {
                valid = false;
                passwdcnfrmBox.BorderBrush = Brushes.Red;
            }
            else
            {
                passwdcnfrmBox.ClearValue(TextBox.BorderBrushProperty);
            }
            if (valid)
            {
                string ErrorMsg = null;
                admin.HireDate = new DateTime(1900, 1, 1);
                admin.BirthDate = new DateTime(1900, 1, 1);
                admin.Password = passwdBox.Password;
                admin.ConfirmPassword = passwdcnfrmBox.Password;
                ErrorMsg = rl.AddEntity(admin, ResortFuncBase.ValidateExists, ResortFuncBase.ValidateEmail, ResortFuncBase.ValidatePassword);
                rl.commitChanges();
                errBlock.Text = ErrorMsg;
                return ErrorMsg == null;
            }
            else
            {
                return false;
            }
        }


        public void PreView()
        {
            throw new NotImplementedException();
        }
    }
}
