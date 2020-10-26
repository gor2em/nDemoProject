using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Models;
using System.Threading.Tasks;
using Core.UnitofWorks;
using Core.Repositories;

namespace Service.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitofWork unitofWork, IRepository<Category> repository) : base(unitofWork, repository)
        {
        }

        public async Task<Category> GetWithCategoryByIdAsync(int categoryId)
        {
            return await _unitOfWork.Category.GetWithCategoriesById(categoryId);
        }
    }
}
