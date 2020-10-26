using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithCategoryByIdAsync(int categoryId);
    }
}
