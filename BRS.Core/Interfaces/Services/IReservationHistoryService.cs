using BRS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRS.Core.Interfaces.Services
{
    public interface IReservationHistoryService
    {
        Task Add(ReservationHistory reservationHistory);
        Task<IEnumerable<ReservationHistory>> GetReservationHistorys();
        Task<ReservationHistory> GetReservationHistoryById(Guid id);
        Task<IEnumerable<ReservationHistory>> GetReservationHistoryByBookId(Guid bookId);
    }
}
