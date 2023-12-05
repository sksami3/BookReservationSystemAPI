using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRS.Core.Interfaces.Repositories;
using BRS.Core.Interfaces.Services;
using BRS.Data.Repositories;
using Inventory.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Web
{
    public static class ServiceResolver
    {
        public static void Resolve(this IServiceCollection services)
        {
            #region service 
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IReservationHistoryService, ReservationHistoryService>();
            #endregion

            #region repositories
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IReservationHistoryRepository, ReservationHistoryRepository>();
            #endregion
        }
    }
}
