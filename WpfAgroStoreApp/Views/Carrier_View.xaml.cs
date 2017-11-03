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
    /// Interaction logic for Carrier_View.xaml
    /// </summary>
    public partial class Carrier_View : Window
    {
        public Carrier_View()
        {
            InitializeComponent();
            this.DataContext = new Carrier_ViewModel();
        }
    }
}
