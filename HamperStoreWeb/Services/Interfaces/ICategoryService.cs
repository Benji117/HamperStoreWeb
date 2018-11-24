using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamperStoreWeb.Services;
using HamperStoreWeb.DataAcess.Models;

namespace HamperStoreWeb.Services
{
    public interface ICategoryService
    {
        Category GetCategoryById(int id);
        Category GetCategories();
        Category CreateCategory(string categoryName);
        Category UpdateCategory(int id, string categoryName);
        void RemoveCategory(int id);
    }
}
