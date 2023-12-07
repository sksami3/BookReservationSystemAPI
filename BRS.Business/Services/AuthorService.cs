using BRS.Core.Entity;
using BRS.Core.Exception;
using BRS.Core.Interfaces.Repositories;
using BRS.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Add(Author Author)
        {
            await _authorRepository.AddAsync(Author);
            await _authorRepository.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _authorRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _authorRepository.All().ToListAsync();
        }

        public async Task Delete(Guid authorId)
        {
            var author = await _authorRepository.FindAsync(authorId);
            if(author == null) 
                new GenericException(Exceptions.AuthorNotFound);

            _authorRepository.Delete(author);
            await _authorRepository.SaveChangesAsync();
        }

        public async Task Update(Author author)
        {
            await _authorRepository.UpdateAuthor(author);
        }
    }
}
