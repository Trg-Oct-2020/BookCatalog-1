using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Domain.Abstractions
{
    public interface IEntity
    {
        String id { get; set; }
    }
}
