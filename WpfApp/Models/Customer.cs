using CursovaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WpfApp.ViewModels;

namespace WpfApp.Models
{
  public class Customer : ViewModelBase, IDataErrorInfo
    {
        private int _id;
        private int _roleId;
        private string _fname;
        private string _lname;
        private RoleDTO _role;
        private string _mail;
        private string _pass;
        private Guid _salt;
        public bool _isEnabled;
        public Dictionary<string, string> ErrorCollection { get; set; } = new Dictionary<string, string>();
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");

            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public int RoleId
        {
            get
            {
                return _roleId;
            }
            set
            {
                _roleId = value;
                OnPropertyChanged("RoleId");
            }
        }
        public string FirstName
        {
            get
            {
                return _fname;
            }
            set
            {
                _fname = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _lname;
            }
            set
            {
                _lname = value;
                OnPropertyChanged("LastName");
            }
        }    
        public virtual RoleDTO Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                OnPropertyChanged("Role");
            }
        }
        public Guid Salt
        {
            get
            {
                return _salt;
            }
            set
            {
                _salt = value;
                OnPropertyChanged("Salt");
            }
        }
     
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string Pass
        {
            get
            {
                return _pass;
            }
            set
            {
                _pass = value;
                OnPropertyChanged("Pass");
            }
        }
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "Mail":
                        if (string.IsNullOrEmpty(Mail))
                        {
                            error = "object cannot be null";
                        }
                        break;

                    case "Pass":
                        if (string.IsNullOrEmpty(Pass))
                        {
                            error = "object cannot be null";
                        }
                        break;
                }
                if (ErrorCollection.ContainsKey(columnName))
                    ErrorCollection[columnName] = error;
                else if (error != null)
                {
                    ErrorCollection.Add(columnName, error);
                }
                OnPropertyChanged("ErrorCollection");
                if (error != null)
                {
                    IsEnabled = false;
                }
                else
                {
                    IsEnabled = true;
                }
                return error;
            }
        }
       
    }
}
