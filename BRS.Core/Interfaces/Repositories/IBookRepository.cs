using System;
using System.Threading.Tasks;
using BRS.Core.Entity;
using BRS.Core.Enums;
using BRS.Core.Interfaces.Repositories.Base;

namespace BRS.Core.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task UpdateBook(Book model, bool isReservationUpdate = false);
        Task SoftDelete(Guid bookId); //locical delete
        Task<IList<Book>> GetBookListByStatus(Status status);
    }
}
