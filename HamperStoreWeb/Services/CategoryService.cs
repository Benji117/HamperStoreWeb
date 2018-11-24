using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HamperStoreWeb.DataAcess.Models;

namespace HamperStoreWeb.Services
{
    public class CategoryService
    {
        private readonly HamperStoreEntities _context;
        //Dependency Injection of HamperStoreEntities Context
        public CategoryService(HamperStoreEntities context)
        {
            //We can now use _context variable to call context within this Service
            _context = context;
        }

        public async Task<Category> GetCategoryById(int id)
        {
          var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
          return category;            
        }

        private async Task<List<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public void CreateCategory(string categoryName)
        {
            if (categoryName != null)
            {
                var newCategory = new Category
                {
                    CategoryName = categoryName 
                };

                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }
        }
        public async Task<Category> UpdateCategory(int id, string categoryName)
        {
            //Search for existing Ctegory Matching this id
           var existingCategory =  await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            //If something is returned update the category Name
            if (existingCategory != null)
            {
                existingCategory.CategoryName = categoryName;
            }
            //Use context to update the modified record
            _context.Update(existingCategory);
            await _context.SaveChangesAsync();
            
            return existingCategory;
                        
        }

        public async Task RemoveCategory(int id)
        {
            //Search for existing Ctegory Matching this id
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            //If something is returned remove the category Name from context
            if (existingCategory != null)
            {
                _context.Categories.Remove(existingCategory);
            }
            //Use context to update the modified record
            await _context.SaveChangesAsync();

        }        
    }
}