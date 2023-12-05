using BRS.Core.Entity;
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

        public async Task Add(Book Book)
        {
            await _bookRepository.AddAsync(Book);
            await _bookRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.All().ToListAsync();
        }
        public async Task<Book> GetBookById(Guid id)
        {
            return await _bookRepository.FindAsync(id);
        }

        public async Task Update(Book Book)
        {
            await _bookRepository.UpdateBook(Book);
        }

        public async Task SoftDelete(Guid bookId)
        {
            await _bookRepository.SoftDelete(bookId);
        }
    }
}