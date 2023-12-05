using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BRS.Core.Entity;

namespace BRS.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        Task Add(Author Author);
        Task<IEnumerable<Author>> GetAuthors();
        Task Update(Author Author);
        Task SoftDelete(Guid AuthorId); //logical delete
        Task<Author> GetAuthorById(Guid id);
    }
}
