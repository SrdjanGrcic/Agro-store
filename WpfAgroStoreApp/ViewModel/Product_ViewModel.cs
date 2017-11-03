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


namespace WpfAgroStoreApp.ViewModel
{
    class Product_ViewModel : ViewModelBase
    {
        List<vwProduct> productList = new List<vwProduct>();
        List<vwCategory> categoryList = new List<vwCategory>();
        List<vwSupplier> supplierList = new List<vwSupplier>();

        vwProduct product = new vwProduct();

        public Product_ViewModel()
        {
            using (Service1Client wcf = new Service1Client())
            {
                productList = wcf.GetAllProducts().ToList();
                categoryList = wcf.GetAllCategories().ToList();
                supplierList = wcf.GetAllSuppliers().ToList();
            }
        }

        public List<vwProduct> Products
        {
            get { return productList; }
        }

        public vwProduct Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }

        //private vwProduct selectedProduct = new vwProduct();
        //public vwProduct SelectedCategory
        //{
        //    get { return selectedProduct; }
        //    set { selectedProduct = value; }
        //}
        private vwSupplier selectedSupplier = new vwSupplier();
        public vwSupplier SelectedSupplier
        {
            get { return selectedSupplier; }
            set { selectedSupplier = value; }
        }
        private vwCategory selectedCategory = new vwCategory();
        public vwCategory SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; }
        }

        public List<vwCategory> CategoryList
        {
            get { return categoryList; }
        }
        public List<vwSupplier> SupplierList
        {
            get { return supplierList; }
        }

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
            if (param.ToString().Equals("btn_Add_Product"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        product.CategoryID = selectedCategory.CategoryID;
                        product.SupplierID = selectedSupplier.SupplierID;
                        wcf.AddProduct(product);
                        MessageBox.Show("Dodat je proizvod.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            if (param.ToString().Equals("btn_UpDateProduct"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite proizvod: " + product.ProductName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.AddProduct(product);
                            MessageBox.Show("Izmenjen je proizvod: " + product.ProductName.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            else if (param.ToString().Equals("btn_DeleteProduct"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        int productID = (int)product.ProductID;
                        bool isProductExist = wcf.IsProductExist(productID);

                        if (isProductExist)
                        {
                            MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete proizvod: " + product.ProductName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (msgRes == MessageBoxResult.Yes)
                            {
                                wcf.DeleteProduct(productID);
                                MessageBox.Show("Obrisan je proizvod: " + product.ProductName.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Izaberite proizvod za brisanje.");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Izaberite proizvod za brisanje.");
                }
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Product"))
            {
                //if (String.IsNullOrEmpty(product.ProductName) || String.IsNullOrEmpty((product.Price).ToString())) //plus 2 x combobox
                //{
                //    return false;
                //}
            }
            return true;
        }

        #endregion
    }
}
