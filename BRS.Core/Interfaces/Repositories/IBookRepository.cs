using System;
using System.Threading.Tasks;
using BRS.Core.Entity;
using BRS.Core.Interfaces.Repositories.Base;

namespace BRS.Core.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task UpdateBook(Book model);
        Task SoftDelete(Guid bookId); //locical delete
    }
}
