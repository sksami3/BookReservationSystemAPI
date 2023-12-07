using BRS.Business.Repositories.Base;
using BRS.Core.Entity;
using BRS.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BRS.Core.Exception;
using Inventory.Data.InventoryContext;

namespace BRS.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private BRSDbContext _context;
        public AuthorRepository(BRSDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task Insert(Author model)
        {
            await AddAsync(model);
            await SaveChangesAsync();
        }

        public async Task UpdateAuthor(Author model)
        {
            var author = await Author(model.Id);
            author.Name = model.Name;
            author.SocialSecurityNo = model.SocialSecurityNo;

            Update(author);
            await SaveChangesAsync();
        }

        public async Task SoftDelete(Guid AuthorId)
        {
            var author = await Author(AuthorId);

            Delete(author);
            await SaveChangesAsync();
        }

        #region Helper
        private async Task<Author> Author(Guid AuthorId)
        {
            var author = await FindAsync(AuthorId);

            if (author == null)
                throw new GenericException(Exceptions.AuthorNotFound);
            return author;
        }
        #endregion
    }
}
