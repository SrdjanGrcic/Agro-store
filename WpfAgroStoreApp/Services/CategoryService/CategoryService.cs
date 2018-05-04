using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WcfService;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Utilities;

namespace WpfAgroStoreApp.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public bool DeleteCategory(Category category)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    if (wcf.IsCategoryExist(category.CategoryID))
                    {
                        MessageBoxResult msgRes = MessageBox.Show(Constants.DeleteCategory + category.CategoryName, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.DeleteCategory(category.CategoryID);
                            MessageBox.Show(Constants.CategoryDeleted + category.CategoryName);
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constants.ChooseCategory);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return false;
        }

        public bool EditCategory(Category category)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    MessageBoxResult msgRes = MessageBox.Show(Constants.EditCategory + category.CategoryName, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msgRes == MessageBoxResult.Yes)
                    {
                        wcf.AddCategory(TransformToServiceModel(category));
                        MessageBox.Show(Constants.CategoryEdited + category.CategoryName);

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

        public List<Category> LoadCategory()
        {
            List<vwCategory> _categoryList = new List<vwCategory>();

            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    return ServiceModelToDomainModel(wcf.GetAllCategories().ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }

        public Category StoreCategory(Category category)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    wcf.AddCategory(TransformToServiceModel(category));
                    //MessageBox.Show("Dodata je kategorija.");

                    return category;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return null;
        }

        #region Private Methods

        private vwCategory TransformToServiceModel(Category category)
        {
            return new vwCategory()
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                CategoryDesc = category.CategoryDesc
            };
        }

        private List<Category> ServiceModelToDomainModel(List<vwCategory> categories)
        {
            List<Category> _categoryList = new List<Category>();

            foreach (var item in categories)
            {
                _categoryList.Add(new Category(item.CategoryID, item.CategoryName, item.CategoryDesc));
            }
            return _categoryList;
        }

        #endregion
    }
}
