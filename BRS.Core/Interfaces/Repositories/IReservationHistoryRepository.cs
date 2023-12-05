using System;
using System.Threading.Tasks;
using BRS.Core.Entity;
using BRS.Core.Interfaces.Repositories.Base;

namespace BRS.Core.Interfaces.Repositories
{
    public interface IReservationHistoryRepository : IBaseRepository<ReservationHistory>
    {
        Task<IList<ReservationHistory>> GetReservationHistoryByBookId(Guid bookId);
    }
}
