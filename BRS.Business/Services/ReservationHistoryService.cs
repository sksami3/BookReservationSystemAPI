using BRS.Core.Entity;
using BRS.Core.Interfaces.Repositories;
using BRS.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Services
{
    public class ReservationHistoryService : IReservationHistoryService
    {
        private readonly IReservationHistoryRepository _reservationHistoryRepository;

        public ReservationHistoryService(IReservationHistoryRepository reservationHistoryRepository)
        {
            _reservationHistoryRepository = reservationHistoryRepository;
        }
        public async Task Add(ReservationHistory ReservationHistory)
        {
            await _reservationHistoryRepository.AddAsync(ReservationHistory);
            await _reservationHistoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReservationHistory>> GetReservationHistoryByBookId(Guid bookId)
        {
            return await _reservationHistoryRepository.GetReservationHistoryByBookId(bookId);
        }

        public async Task<ReservationHistory> GetReservationHistoryById(Guid id)
        {
            return await _reservationHistoryRepository.FindAsync(id);
        }

        public async Task<IEnumerable<ReservationHistory>> GetReservationHistories()
        {
            return await _reservationHistoryRepository.All().ToListAsync();
        }
    }
}
