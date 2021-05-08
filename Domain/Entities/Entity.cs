using BookCatalog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.MicroService.Domain.Entities
{
    public class Entity: IEntity
    {
        public String id { get; set; }
    }
}
