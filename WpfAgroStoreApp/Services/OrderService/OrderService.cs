using System;
using System.Collections.Generic;
using System.Windows;
using WcfService;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Utilities;
using WpfAgroStoreApp.Views;

namespace WpfAgroStoreApp.Services.OrderService
{
    public class OrderService : IOrderService
    {
        #region Public Methods

        public bool DeleteOrder(Order order)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    if (wcf.IsOrderExist(order.OrderID))
                    {
                        MessageBoxResult msgRes = MessageBox.Show(Constants.DeleteOrder + order.OrderID, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.DeleteOrder(order.OrderID);
                            MessageBox.Show(Constants.OrderDeleted + order.OrderID);

                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constants.ChooseOrder);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return false;
        }

        public bool EditOrder(Order order)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    MessageBoxResult msgRes = MessageBox.Show(Constants.EditOrder + order.OrderID, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msgRes == MessageBoxResult.Yes)
                    {
                        wcf.AddOrder(TransformToServiceModel(order));
                        MessageBox.Show(Constants.OrderEdited + order.OrderID);
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

        public List<Order> LoadOrders()
        {
            throw new NotImplementedException();
        }

        public Order StoreOrder(int customerId, int carrierId, int paymentId)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    Order order = new Order();

                    order.CustomerID = customerId;
                    order.CarrierID = carrierId;
                    order.PaymentID = paymentId;

                    vwOrder newOrder = wcf.AddOrder(TransformToServiceModel(order));
                    OrderDetails_View orderDetailsView = new OrderDetails_View(newOrder);
                    orderDetailsView.ShowDialog();

                    return order;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return null;
        }

        #endregion

        #region Private Methods

        private vwOrder TransformToServiceModel(Order order)
        {
            return new vwOrder()
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                PaymentID = order.PaymentID
            };
        }

        #endregion
    }
}
