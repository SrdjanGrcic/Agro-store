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
    class Category_ViewModel : ViewModelBase
    {
        List<vwCategory> categoryList = new List<vwCategory>();
        vwCategory category = new vwCategory();

        public Category_ViewModel()
        {
            using (Service1Client wcf = new Service1Client())
            {
                categoryList = wcf.GetAllCategories().ToList();
            }
        }

        public List<vwCategory> Categories
        {
            get { return categoryList; }
        }

        public vwCategory Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
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
            if (param.ToString().Equals("btn_Add_Category"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        wcf.AddCategory(category);
                        //IsUpdateSupplier = true;
                        MessageBox.Show("Dodata je kategorija.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            if (param.ToString().Equals("btn_UpDateCategory"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite dobavljaca: " + category.CategoryName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.AddCategory(category);
                            MessageBox.Show("Izmenjen je dobavljac: " + category.CategoryName.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            else if (param.ToString().Equals("btn_DeleteCategory"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        int catID = (int)category.CategoryID;
                        bool isCategoryExist = wcf.IsCategoryExist(catID);

                        if (isCategoryExist)
                        {
                            MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete dobavljaca: " + category.CategoryName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (msgRes == MessageBoxResult.Yes && isCategoryExist)
                            {
                                wcf.DeleteCategory(catID);
                                MessageBox.Show("Obrisan je dobavljac: " + category.CategoryName.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Izaberite kategoriju za brisanje.");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Izaberite kategoriju za brisanje.");
                }
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Customer"))
            {
                if (String.IsNullOrEmpty(category.CategoryName))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}
