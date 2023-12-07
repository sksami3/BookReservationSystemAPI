using BRS.Core.Entity;
using BRS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRS.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task<Book> Add(Book book);
        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Book>> GetBookListByStatus(Status status);
        Task<Book> GetBookById(Guid id);
        Task Update(Book book, bool isReservationUpdate = false);
        Task SoftDelete(Guid bookId); //logical delete
        Task<Book> ReserveBook(Guid bookId, string comment);
        Task<Book> UnreserveBook(Guid bookId);
    }
}
