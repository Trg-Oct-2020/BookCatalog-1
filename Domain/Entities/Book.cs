using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Domain.Entities
{
    public class Book
    {
        public String id { get; set; }
        public String title { get; set; }
        public String author { get; set; }
        public String isbn { get; set; }
        public String publishedDate { get; set; }

    }
}
