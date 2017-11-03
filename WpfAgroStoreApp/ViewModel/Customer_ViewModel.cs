using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WcfService;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.ServiceReference1;


namespace WpfAgroStoreApp.ViewModel
{
    class Customer_ViewModel : ViewModelBase
    {
        List<vwCustomer> customerList = new List<vwCustomer>();
        vwCustomer customer = new vwCustomer();

        public Customer_ViewModel()
        {
            using (Service1Client wcf = new Service1Client())
            {
                customerList = wcf.GetAllCustomers().ToList();
            }
        }

        public List<vwCustomer> Customers
        {
            get { return customerList; }
        }

        public vwCustomer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }
        
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
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        wcf.AddCustomer(customer);
                        //IsUpdateSupplier = true;
                        MessageBox.Show("Dodat je kupac.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            if (param.ToString().Equals("btn_UpDateCustomer"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite kupca: " + customer.CustomerName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.AddCustomer(customer);
                            MessageBox.Show("Izmenjen je dobavljac: " + customer.CustomerName.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            else if (param.ToString().Equals("btn_DeleteCustomer"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        int custID = (int)customer.CustomerID;
                        bool isCustomerExist = wcf.IsCustomerExist(custID);

                        if (isCustomerExist)
                        {
                            MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete dobavljaca: " + customer.CustomerName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (msgRes == MessageBoxResult.Yes)
                            {
                                wcf.DeleteCustomer(custID);
                                MessageBox.Show("Obrisan je kupac: " + customer.CustomerName.ToString());
                            }
                        }                        
                        else
                        {
                            MessageBox.Show("Izaberite kupca za brisanje.");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Izaberite kupca za brisanje.");
                }
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Customer"))
            {
                if (String.IsNullOrEmpty(customer.CustomerName) || String.IsNullOrEmpty(customer.Address) || String.IsNullOrEmpty(customer.City))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
