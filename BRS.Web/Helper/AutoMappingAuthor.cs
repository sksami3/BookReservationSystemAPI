using AutoMapper;
using BRS.Core.Entity;
using BRS.Core.ViewModel;

namespace BRS.Web.Helper
{
    public class AutoMappingAuthor : Profile
    {
        public AutoMappingAuthor()
        {
            //source mapping to destination
            CreateMap<Author, AuthorEditVM>().ReverseMap();
        }
    }
}
