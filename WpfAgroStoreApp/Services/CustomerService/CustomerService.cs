using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WcfService;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Utilities;

namespace WpfAgroStoreApp.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        #region Public Methods

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    if (wcf.IsCustomerExist(customer.CustomerID))
                    {
                        MessageBoxResult msgRes = MessageBox.Show(Constants.DeleteCustomer + customer.CustomerName, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.DeleteCustomer(customer.CustomerID);
                            MessageBox.Show(Constants.CustomerDeleted + customer.CustomerName);

                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constants.ChooseCustomer);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return false;
        }

        public bool EditCustomer(Customer customer)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    MessageBoxResult msgRes = MessageBox.Show(Constants.EditCustomer + customer.CustomerName, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msgRes == MessageBoxResult.Yes)
                    {
                        wcf.AddCustomer(TransformToServiceModel(customer));
                        MessageBox.Show(Constants.CustomerEdited + customer.CustomerName);

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return false;
        }

        public List<Customer> LoadCustomers()
        {
            using (Service1Client wcf = new Service1Client())
            {
                return ServiceModelToDomainModel(wcf.GetAllCustomers().ToList());
            }
        }

        public Customer StoreCustomer(Customer customer)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    wcf.AddCustomer(TransformToServiceModel(customer));

                    return customer;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);

                return customer;
            }
        }

        #endregion

        #region Private Methods

        private List<Customer> ServiceModelToDomainModel(List<vwCustomer> customers)
        {
            List<Customer> _customerList = new List<Customer>();

            foreach (var item in customers)
            {
                _customerList.Add(new Customer(item.CustomerID, item.CustomerName, item.City, item.Address, item.Phone));
            }
            return _customerList;
        }

        private vwCustomer TransformToServiceModel(Customer customer)
        {
            return new vwCustomer()
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                City = customer.City,
                Address = customer.Address,
                Phone = customer.Phone
            };
        }

        #endregion
    }
}
