using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SelaResortUI
{
    class EmployeeViewModel : INotifyPropertyChanged
    {
        private CommonEmployee _employee;
        private bool _inEdit;
        public string Error { get; set; }
        public string InitialEmail { get; set; }
        public string InitialPassword { get; set; }
        public bool IsEditing {
            get
            {
                return _inEdit;
            }
            set
            {
                _inEdit = value;
                OnPropertyChanged("IsEditing");
            }
        }
        public CommonEmployee EmployeeObject
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged("EmployeeObject");
            }
        }
        public ObservableCollection<CommonEmployee> Employees { get; set; }
        public Array Positions {
            get
            {
                return Enum.GetValues(typeof(Positions));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
