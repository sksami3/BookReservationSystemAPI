using AutoMapper;
using BRS.Core.Entity;
using BRS.Core.ViewModel.Book;

namespace BRS.Web.Helper
{
    public class AutoMappingBook : Profile
    {
        public AutoMappingBook()
        {
            //source mapping to destination
            CreateMap<Book, BookVM>().ReverseMap();
        }
    }

    public class AutoMappingBookEdit : Profile
    {
        public AutoMappingBookEdit()
        {
            //source mapping to destination
            CreateMap<Book, BookEditInsertVM>().ReverseMap();
        }
    }
}
