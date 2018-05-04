using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAgroStoreApp.Model
{
    public class Category
    {
        public Category()
        {
        }

        public Category(int categoryId, string categoryName, string categoryDesc)
        {
            CategoryID = categoryId;
            CategoryName = categoryName;
            CategoryDesc = categoryDesc;
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
    }
}
