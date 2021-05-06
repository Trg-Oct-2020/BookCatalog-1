using BookCatalog.MicroService.DTOs;
using BookCatalog.MicroService.Entities;
using AutoMapper;

namespace BookCatalog.MicroService.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
