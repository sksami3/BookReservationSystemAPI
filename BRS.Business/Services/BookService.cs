using BRS.Core.Entity;
using BRS.Core.Enums;
using BRS.Core.Exception;
using BRS.Core.Interfaces.Repositories;
using BRS.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Add(Book book)
        {
            if(book.AuthorId == default(Guid))
                book.AuthorId = null;

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.All().ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBookListByStatus(Status status)
        {
            return await _bookRepository.GetBookListByStatus(status);
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _bookRepository.FindAsync(id);
        }

        public async Task Update(Book book, bool isReservationUpdate = false)
        {
            await _bookRepository.UpdateBook(book, isReservationUpdate);
        }

        public async Task SoftDelete(Guid bookId)
        {
            await _bookRepository.SoftDelete(bookId);
        }

        public async Task<Book> ReserveBook(Guid bookId, string comment)
        {
            var book = await GetBookById(bookId);
            if (book == null)
                throw new GenericException(Exceptions.BookNotFound);

            if(book.Status == ((int)Status.reserved))
                throw new GenericException(Exceptions.BookAlreadyReserved);
            else
            {
                book.Status = ((int)Status.reserved);
                book.Comment = comment;
                await Update(book, true);

                return book;
            }
        }

        public async Task<Book> UnreserveBook(Guid bookId)
        {
            var book = await GetBookById(bookId);
            if (book == null)
                throw new GenericException(Exceptions.BookNotFound);

            if (book.Status == ((int)Status.unreserved))
                throw new GenericException(Exceptions.BookAlreadyUnreserved);
            else
            {
                book.Status = ((int)Status.unreserved);
                book.Comment = "";
                await Update(book, true);

                return book;
            }
        }
    }
}