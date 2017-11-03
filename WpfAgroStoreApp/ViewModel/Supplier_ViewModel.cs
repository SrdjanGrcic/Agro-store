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
    class Supplier_ViewModel : ViewModelBase
    {
        List<vwSupplier> supplierList = new List<vwSupplier>();
        vwSupplier supplier = new vwSupplier();

        public Supplier_ViewModel()
        {
            using (Service1Client wcf = new Service1Client())
            {
                supplierList = wcf.GetAllSuppliers().ToList();
            }
        }

        public List<vwSupplier> Suppliers
        {
            get { return supplierList; }
        }

        public vwSupplier Suplier
        {
            get { return supplier; }
            set
            {
                supplier = value;
                OnPropertyChanged("Suplier");
            }
        }
        
        public ICommand Show
        {
            get
            {
                return new RelayCommand(x => Execute(x), x => CanExecute(x));
            }
        }

        private void Execute(object param)
        {
            if (param.ToString().Equals("btn_Add_Supplier"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        wcf.AddSupplier(supplier);
                        //IsUpdateSupplier = true;
                        MessageBox.Show("Dodat je dobavljac.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            if (param.ToString().Equals("btn_UpDateSupplier"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite dobavljaca: " + supplier.SupplierName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.AddSupplier(supplier);
                            MessageBox.Show("Izmenjen je dobavljac: " + supplier.SupplierName.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            else if (param.ToString().Equals("btn_DeleteSupplier"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        int supID = (int)supplier.SupplierID;
                        bool isSupplierExist = wcf.IsSupplierExist(supID);

                        if (isSupplierExist)
                        {
                            MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete dobavljaca: " + supplier.SupplierName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (msgRes == MessageBoxResult.Yes)
                            {
                                wcf.DeleteSupplier(supID);
                                MessageBox.Show("Obrisan je dobavljac: " + supplier.SupplierName.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Izaberite dobavljaca za brisanje.");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Izaberite dobavljaca za brisanje.");
                }
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Supplier"))
            {
                if (String.IsNullOrEmpty(supplier.SupplierName) || String.IsNullOrEmpty(supplier.Address) || String.IsNullOrEmpty(supplier.City) || String.IsNullOrEmpty(supplier.Phone))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
