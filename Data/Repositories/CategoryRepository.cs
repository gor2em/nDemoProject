using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private Demo2DbContext demo2DbContext
        {
            get => _context as Demo2DbContext;
        }
        public CategoryRepository(Demo2DbContext demo2DbContext) : base(demo2DbContext)
        {
        }

        public async Task<Category> GetWithCategoriesById(int id)
        {
            return await demo2DbContext.Categories.Include(x => x.Books).SingleOrDefaultAsync(x => x.CategoryId == id);
        }
    }
}
