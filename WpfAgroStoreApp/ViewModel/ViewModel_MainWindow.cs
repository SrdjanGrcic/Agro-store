using System.Windows.Input;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.Views;

namespace WpfAgroStoreApp.ViewModel
{
    class ViewModel_MainWindow : ViewModelBase
    {
        public ICommand Show
        {
            get
            {
                return new RelayCommand(x => Execute(x), x => CanExecute(x));
            }
        }

        private void Execute(object param)
        {
            if (param.ToString().Equals("btn_Supplier"))
            {
                Supplier_View suppView = new Supplier_View();
                suppView.ShowDialog();
            }
            if (param.ToString().Equals("btn_Customer"))
            {
                Customer_View custView = new Customer_View();
                custView.ShowDialog();
            }
            if (param.ToString().Equals("btn_Product"))
            {
                Product_View productView = new Product_View();
                productView.ShowDialog();
            }
            if (param.ToString().Equals("btn_Category"))
            {
                Category_View categoryView = new Category_View();
                categoryView.ShowDialog();
            }
            if (param.ToString().Equals("btn_Payment"))
            {
                Payment_View paymentView = new Payment_View();
                paymentView.ShowDialog();
            }
            if (param.ToString().Equals("btn_Carrier"))
            {
                Carrier_View carrierView = new Carrier_View();
                carrierView.ShowDialog();
            }
            if (param.ToString().Equals("btn_Order"))
            {
                Order_View orderView = new Order_View();
                orderView.ShowDialog();
            }
            //if (param.ToString().Equals("btn_OrderDetails"))
            //{
            //    OrderDetails_View orderDetailsView = new OrderDetails_View(vwOrder);
            //    orderDetailsView.ShowDialog();
            //}
        }

        private bool CanExecute(object param)
        {
            return true;
        }
    }
}
