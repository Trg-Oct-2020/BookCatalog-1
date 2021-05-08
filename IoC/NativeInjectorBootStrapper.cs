using BookCatalog.Application.AutoMapper;
using BookCatalog.MicroService.Messaging.Send.Options;
using BookCatalog.MicroService.Messaging.Send.Sender;
using BookCatalog.Infra.Data.Repositories;
using BookCatalog.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace BookCatalog.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {            
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
            services.AddSwaggerGen();
            services.AddScoped<IBookSender, BookSender>();
        }
    }
}
