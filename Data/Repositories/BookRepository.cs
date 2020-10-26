using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private Demo2DbContext demo2DbContext
        {
            get => _context as Demo2DbContext;
        }
        public BookRepository(Demo2DbContext demo2DbContext) : base(demo2DbContext)
        {
        }

        public async Task<Book> GetWithBooksById(int id)
        {
            return await demo2DbContext.Books.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
