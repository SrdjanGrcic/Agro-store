using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WcfService;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Services.CustomerService;

namespace WpfAgroStoreApp.ViewModel
{
    class Customer_ViewModel : ViewModelBase
    {
        #region Private Fields

        private List<Customer> _customerList;
        private Customer _customer;

        private CustomerService _customerService;

        #endregion

        #region Public Constructor

        public Customer_ViewModel()
        {
            _customerList = new List<Customer>();
            _customer = new Customer();

            _customerService = new CustomerService();
        }

        #endregion

        #region Public Properties

        public List<Customer> Customers
        {
            get { return _customerList; }
            set
            {
                _customerList = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        #endregion

        #region IComandButtons

        public ICommand Show
        {
            get
            {
                return new RelayCommand(x => Execute(x), x => CanExecute(x));
            }
        }

        private void Execute(object param)
        {
            if (param.ToString().Equals("btn_Add_Customer"))
            {
                _customerService.StoreCustomer(Customer);
            }

            if (param.ToString().Equals("btn_UpDateCustomer"))
            {
                _customerService.EditCustomer(Customer);
            }

            else if (param.ToString().Equals("btn_DeleteCustomer"))
            {
                _customerService.DeleteCustomer(Customer);
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Customer"))
            {
                if (String.IsNullOrEmpty(_customer.CustomerName) || String.IsNullOrEmpty(_customer.Address) || String.IsNullOrEmpty(_customer.City))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
