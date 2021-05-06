using AutoMapper;
using BookCatalog.MicroService.DTOs;
using BookCatalog.MicroService.Entities;

namespace BookCatalog.MicroService.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BookDTO, Book>();
        }
    }
}
