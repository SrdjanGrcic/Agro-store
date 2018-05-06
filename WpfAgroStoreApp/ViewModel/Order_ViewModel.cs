using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WcfService;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Services.CarrierService;
using WpfAgroStoreApp.Services.CustomerService;
using WpfAgroStoreApp.Services.OrderService;
using WpfAgroStoreApp.Views;


namespace WpfAgroStoreApp.ViewModel
{
    class Order_ViewModel : ViewModelBase
    {
        #region Private Fields

        private Order order = new Order();

        private List<Order> _orderList = new List<Order>();
        private List<Customer> _customerList = new List<Customer>();
        private List<Carrier> _carrierList = new List<Carrier>();
        private List<Payment> _paymentList = new List<Payment>();

        private CarrierService _carrierService;
        private OrderService _orderService;
        private CustomerService _customerService;
        //private PaymentService _paymentService;

        #endregion

        #region Public Constructor

        public Order_ViewModel()
        {
            using (Service1Client wcf = new Service1Client())
            {
                _carrierService = new CarrierService();
                _customerService = new CustomerService();
                _orderService = new OrderService();
                //_paymentService = new PaymentService();

                _carrierList = _carrierService.LoadCarriers();
                _orderList = _orderService.LoadOrders();
                _customerList = _customerService.LoadCustomers();
                //paymentList = _paymentService.;
            }
        }

        #endregion

        #region Properties

        //Orders
        public List<Order> Orders
        {
            get { return _orderList; }
        }
        public Order Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        //Customers
        public List<Customer> Customers
        {
            get { return _customerList; }
        }
        private Customer customer = new Customer();
        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        //Carrier
        public List<Carrier> Carriers
        {
            get { return _carrierList; }
        }
        private Carrier carrier = new Carrier();
        public Carrier Carrier
        {
            get { return carrier; }
            set
            {
                carrier = value;
                OnPropertyChanged(nameof(Carrier));
            }
        }

        //Payment
        public List<Payment> Payments
        {
            get { return _paymentList; }
        }
        private Payment payment = new Payment();
        public Payment Payment
        {
            get { return payment; }
            set
            {
                payment = value;
                OnPropertyChanged(nameof(Payment));
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
            if (param.ToString().Equals("btn_Proceed_Order"))
            {
                _orderService.StoreOrder(Customer.CustomerID, Carrier.CarrierID, Payment.PaymentID);
            }

            if (param.ToString().Equals("btn_UpDateOrder"))
            {
                _orderService.EditOrder(Order);
            }

            else if (param.ToString().Equals("btn_DeleteOrder"))
            {
                _orderService.DeleteOrder(Order);
            }
        }
        
        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Order"))
            {
                if (Order == null)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
