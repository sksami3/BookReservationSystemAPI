using BRS.Business.Repositories.Base;
using BRS.Core.Entity;
using BRS.Core.Exception;
using BRS.Core.Interfaces.Repositories;
using Inventory.Data.InventoryContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRS.Data.Repositories
{
    public class ReservationHistoryRepository : BaseRepository<ReservationHistory>, IReservationHistoryRepository
    {
        private BRSDbContext _context;
        public ReservationHistoryRepository(BRSDbContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<IList<ReservationHistory>> GetReservationHistoryByBookId(Guid bookId)
        {
            var histories = await All(x => x.BookId.Equals(bookId)).OrderBy(x => x.CreateDate).ToListAsync();

            return histories;
        }
    }
}
