using System;
using System.Net;
using System.Threading.Tasks;
using BRS.Business.Repositories.Base;
using BRS.Core.Entity;
using BRS.Core.Enums;
using BRS.Core.Exception;
using BRS.Core.Interfaces.Repositories;
using Inventory.Data.InventoryContext;
using Microsoft.EntityFrameworkCore;

namespace BRS.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private BRSDbContext _context;
        public BookRepository(BRSDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task UpdateBook(Book model, bool isReservationUpdate = false)
        {
            var book = await Book(model.Id);

            book.Title = model.Title;
            book.AuthorId = model.AuthorId;
            if (isReservationUpdate)
            {
                book.Status = model.Status;
                book.Comment = model.Comment;
            }

            Update(book);
            await SaveChangesAsync();
        }

        public async Task SoftDelete(Guid bookId)
        {
            var book = await Book(bookId);
            if (book == null)
                throw new GenericException(Exceptions.BookNotFound);
            else if (book.IsDelete)
                throw new GenericException(Exceptions.BookAlreadyDeleted);
            else
                book.IsDelete = true;

            Update(book);
            await SaveChangesAsync();
        }

        public async Task<IList<Book>> GetBookListByStatus(Status status)
        {
            var listByStatus = All(x => x.Status.Equals((int)status) && !x.IsDelete);

            return await listByStatus.ToListAsync();
        }

        #region helper
        private async Task<Book> Book(Guid BookId)
        {
            var Book = await FindAsync(BookId);
            if (Book == null)
                throw new GenericException(Exceptions.BookNotFound);

            return Book;
        }
        #endregion
    }
}
