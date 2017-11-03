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
using WpfAgroStoreApp.ViewModel;

namespace WpfAgroStoreApp.Views
{
    /// <summary>
    /// Interaction logic for Supplier_View.xaml
    /// </summary>
    public partial class Supplier_View : Window
    {
        public Supplier_View()
        {
            InitializeComponent();
            this.DataContext = new Supplier_ViewModel();
        }
    }
}
