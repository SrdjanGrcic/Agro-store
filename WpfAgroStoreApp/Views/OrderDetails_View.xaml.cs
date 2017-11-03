using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WcfService;
using WpfAgroStoreApp.ViewModel;

namespace WpfAgroStoreApp.Views
{
    /// <summary>
    /// Interaction logic for OrderDetails_View.xaml
    /// </summary>
    public partial class OrderDetails_View : Window
    {
        public OrderDetails_View(vwOrder incomingOrder)
        {
            InitializeComponent();
            this.DataContext = new OrderDetails_ViewModel(this, incomingOrder);
        }
    }
}
