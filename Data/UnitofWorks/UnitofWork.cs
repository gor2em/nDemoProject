using Core.Repositories;
using Core.UnitofWorks;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitofWorks
{
    public class UnitofWork : IUnitofWork
    {
        private readonly Demo2DbContext _context;
        private BookRepository _bookRepository;
        private CategoryRepository _categoryRepository;
        public UnitofWork(Demo2DbContext context)
        {
            _context = context;
        }
        public IBookRepository Book => _bookRepository = _bookRepository ?? new BookRepository(_context);
        public ICategoryRepository Category => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges(); 
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
