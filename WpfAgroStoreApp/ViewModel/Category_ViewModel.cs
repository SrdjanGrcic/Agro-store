using System;
using System.Collections.Generic;
using System.Windows.Input;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.Services.CategoryService;

namespace WpfAgroStoreApp.ViewModel
{
    class Category_ViewModel : ViewModelBase
    {
        #region Private Fields

        private List<Category> _categoryList;
        private Category _category;

        private CategoryService _categoryService;

        #endregion

        #region Public Constructor

        public Category_ViewModel()
        {
            _categoryList = new List<Category>();
            _category = new Category();
            _categoryService = new CategoryService();

            Categories = _categoryService.LoadCategory();
        }

        #endregion

        #region Public Properties

        public List<Category> Categories
        {
            get { return _categoryList; }
            set
            {
                _categoryList = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
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
            if (param.ToString().Equals("btn_Add_Category"))
            {
                _categoryService.StoreCategory(Category);
            }

            if (param.ToString().Equals("btn_UpDateCategory"))
            {
                _categoryService.EditCategory(Category);
            }

            else if (param.ToString().Equals("btn_DeleteCategory"))
            {
                _categoryService.DeleteCategory(Category);
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Customer"))
            {
                if (String.IsNullOrEmpty(_category.CategoryName))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
