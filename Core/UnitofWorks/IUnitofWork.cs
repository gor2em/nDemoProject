using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitofWorks
{
    public interface IUnitofWork
    {
        ICategoryRepository Category { get; }
        IBookRepository Book { get; }
        Task CommitAsync();
        void Commit();
    }
}
