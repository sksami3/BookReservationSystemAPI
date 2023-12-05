using BRS.Core.Entity;
using BRS.Core.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRS.Core.Interfaces.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task SoftDelete(Guid paymentMethodId); //logical delete
        Task UpdateAuthor(Author author);
    }
}
