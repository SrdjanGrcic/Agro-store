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
using WpfAgroStoreApp.Views;


namespace WpfAgroStoreApp.ViewModel
{
    class OrderDetails_ViewModel : ViewModelBase
    {
        OrderDetails_View ordView;

        vwOrder order = new vwOrder(); 
        vwOrderDetails orderDetails = new vwOrderDetails();
        private List<vwOrderDetails> orderDetailsList = new List<vwOrderDetails>();
        private List<vwProduct> productList = new List<vwProduct>();

        vwProduct product = new vwProduct();

        public OrderDetails_ViewModel(OrderDetails_View orderView, vwOrder orderIncoming)
        {
            ordView = orderView;
            order = orderIncoming;

            using (Service1Client wcf = new Service1Client())
            {
                orderDetailsList = wcf.GetAllOrderDetails().ToList();
                productList = wcf.GetAllProducts().ToList();
            }
        }
        
        //public OrderDetails_ViewModel()
        //{
        //    using (Service1Client wcf = new Service1Client())
        //    {
        //        orderDetailsList = wcf.GetAllOrderDetails().ToList();
        //        supplierList = wcf.GetAllSuppliers().ToList();
        //    }
        //}

        #region Properties

        public List<vwOrderDetails> OrderDetailsList {
            get { return orderDetailsList; }
        }

        public List<vwProduct> ProductList
        {
            get { return productList; }
        }

        public vwOrder Order
        {
            get { return order; }
        }

        public vwOrderDetails OrderDetails {
            get { return orderDetails; }
            set{orderDetails = value;}
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
            if (param.ToString().Equals("btn_Add_OrderDetails"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        orderDetails.OrderID = order.OrderID;
                        orderDetails.ProductID = order.OrderID;
                        vwOrderDetails newOrderDetails = wcf.AddOrderDetails(orderDetails);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            //if (param.ToString().Equals("btn_UpDateOrder"))
            //{
            //    try
            //    {
            //        using (Service1Client wcf = new Service1Client())
            //        {
            //            MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite narudzbinu broj: " + order.OrderID.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //            if (msgRes == MessageBoxResult.Yes)
            //            {
            //                wcf.AddOrder(order);
            //                MessageBox.Show("Izmenjena je narudzbina: " + order.OrderID.ToString());
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Error");
            //    }
            //}

            //else if (param.ToString().Equals("btn_DeleteOrder"))
            //{
            //    try
            //    {
            //        using (Service1Client wcf = new Service1Client())
            //        {
            //            int ordID = (int)order.OrderID;
            //            bool isOrderExist = wcf.IsOrderExist(ordID);

            //            if (isOrderExist)
            //            {
            //                MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete narudzbinu: " + order.OrderID.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //                if (msgRes == MessageBoxResult.Yes)
            //                {
            //                    wcf.DeleteOrder(ordID);
            //                    MessageBox.Show("Obrisana je naruzbina: " + order.OrderID.ToString());
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Izaberite narudzbinu za brisanje.");
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Izaberite narudzbinu za brisanje.");
            //    }
            //}
        }

        private bool CanExecute(object param)
        {
            //if (param.ToString().Equals("btn_Add_Order"))
            //{
            //    if (order.CustomerID == null)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        #endregion
    }
}
