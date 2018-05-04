using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WcfService;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Views;


namespace WpfAgroStoreApp.ViewModel
{
    class Order_ViewModel : ViewModelBase
    {
        vwOrder order = new vwOrder();
        List<vwOrder> orderList = new List<vwOrder>();
        private List<vwCustomer> customerList = new List<vwCustomer>();
        private List<vwCarrier> carrierList = new List<vwCarrier>();
        private List<vwPayment> paymentList = new List<vwPayment>();

        public Order_ViewModel()
        {
            using (Service1Client wcf = new Service1Client())
            {
                orderList = wcf.GetAllOrders().ToList();
                customerList = wcf.GetAllCustomers().ToList();
                carrierList = wcf.GetAllCarriers().ToList();
                paymentList = wcf.GetAllPayments().ToList();
            }
        }
        #region Properties

        //Orders
        public List<vwOrder> Orders
        {
            get { return orderList; }
        }
        public vwOrder Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }

        //Customers
        public List<vwCustomer> Customers
        {
            get { return customerList; }
        }
        private vwCustomer customer = new vwCustomer();
        public vwCustomer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }

        //Carrier
        public List<vwCarrier> Carriers
        {
            get { return carrierList; }
        }
        private vwCarrier carrier = new vwCarrier();
        public vwCarrier Carrier
        {
            get { return carrier; }
            set
            {
                carrier = value;
                OnPropertyChanged("Carrier");
            }
        }

        //Payment
        public List<vwPayment> Payments
        {
            get { return paymentList; }
        }
        private vwPayment payment = new vwPayment();
        public vwPayment Payment
        {
            get { return payment; }
            set
            {
                payment = value;
                OnPropertyChanged("Payment");
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
                AddOrder();
            }

            if (param.ToString().Equals("btn_UpDateOrder"))
            {
                EditOrder();
            }

            else if (param.ToString().Equals("btn_DeleteOrder"))
            {
                DeleteOrder();
            }
        }

        private void DeleteOrder()
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    int ordID = (int)order.OrderID;
                    bool isOrderExist = wcf.IsOrderExist(ordID);

                    if (isOrderExist)
                    {
                        MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete narudzbinu: " + order.OrderID.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.DeleteOrder(ordID);
                            MessageBox.Show("Obrisana je naruzbina: " + order.OrderID.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Izaberite narudzbinu za brisanje.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Izaberite narudzbinu za brisanje.");
            }
        }

        private void EditOrder()
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite narudzbinu broj: " + order.OrderID.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msgRes == MessageBoxResult.Yes)
                    {
                        wcf.AddOrder(order);
                        MessageBox.Show("Izmenjena je narudzbina: " + order.OrderID.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void AddOrder()
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    order.CustomerID = Customer.CustomerID;
                    order.CarrierID = Carrier.CarrierID;
                    order.PaymentID = Payment.PaymentID;

                    vwOrder newOrder = wcf.AddOrder(order);
                    OrderDetails_View orderDetailsView = new OrderDetails_View(newOrder);
                    orderDetailsView.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Order"))
            {
                if (order.CustomerID == null)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
