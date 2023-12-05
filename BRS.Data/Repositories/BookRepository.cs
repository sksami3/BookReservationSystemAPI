using System;
using System.Net;
using System.Threading.Tasks;
using BRS.Business.Repositories.Base;
using BRS.Core.Entity;
using BRS.Core.Exception;
using BRS.Core.Interfaces.Repositories;
using Inventory.Data.InventoryContext;

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

        public async Task UpdateBook(Book model)
        {
            var book = await Book(model.Id);

            book.Title = model.Title;
            book.Author = model.Author;
            book.Status = model.Status;
            book.Comment = model.Comment;

            Update(book);
            await SaveChangesAsync();
        }

        public async Task SoftDelete(Guid bookId)
        {
            var book = await Book(bookId);
            if (book == null)
                throw new GenericException(Exceptions.BookNotFound);
            else
                book.IsDelete = true;

            Update(book);
            await SaveChangesAsync();
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
