using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAgroStoreApp.Model;

namespace WpfAgroStoreApp.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> LoadCategory();
        Category StoreCategory(Category category);
        bool EditCategory(Category category);
        bool DeleteCategory(Category category);
    }
}
