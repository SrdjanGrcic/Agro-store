using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAgroStoreApp.Model;

namespace WpfAgroStoreApp.Services.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> LoadCustomers();
        Customer StoreCustomer(Customer customer);
        bool EditCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
    }
}
