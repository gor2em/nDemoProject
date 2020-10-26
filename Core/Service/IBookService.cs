using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IBookService : IService<Book>
    {
        Task<Book> GetWithBookyByIdAsync(int bookId);
    }
}
