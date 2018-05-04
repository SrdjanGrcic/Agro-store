using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAgroStoreApp.Model
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(int customerId, string customerName, string address, string city, string phone)
        {
            CustomerID = customerId;
            CustomerName = customerName;
            Address = address;
            City = city;
            Phone = phone;
        }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
