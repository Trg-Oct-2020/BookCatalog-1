using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Entities;
using AutoMapper;

namespace BookCatalog.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
