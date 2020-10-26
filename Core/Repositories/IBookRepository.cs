using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetWithBooksById(int id);
    }
}
