using BookCatalog.Domain.Abstractions;
using System;

namespace BookCatalog.MicroService.Domain.Entities
{
    public class Entity : IEntity
    {
        public String id { get; set; }
    }
}
