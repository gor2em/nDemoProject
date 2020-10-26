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
    public class BookService : Service<Book>, IBookService
    {
        public BookService(IUnitofWork unitofWork, IRepository<Book> repository) : base(unitofWork, repository)
        {
        }

        public async Task<Book> GetWithBookyByIdAsync(int bookId)
        {
            return await _unitOfWork.Book.GetWithBooksById(bookId);
        }
    }
}
