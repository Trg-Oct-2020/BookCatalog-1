using BookCatalog.Application.AutoMapper;
using BookCatalog.Application.Services;
using BookCatalog.Infra.Persistence.Json.Repositories;
using BookCatalog.Infra.Persistence.Repositories;
using BookCatalog.MicroService.Messaging.Send.Sender;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalog.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, JSonBookRepository>();
            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
            services.AddSwaggerGen();
            services.AddScoped<IBookSender, BookSender>();
        }
    }
}
