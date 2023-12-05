using BRS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRS.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task Add(Book book);
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(Guid id);
        Task Update(Book book);
        Task SoftDelete(Guid bookId); //logical delete
    }
}
