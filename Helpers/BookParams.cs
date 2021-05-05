﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.MicroService.Helpers
{
    public class BookParams
    {
        public string title { get; set; } = "";
        public string author { get; set; } = "";
        public string isbn { get; set; } = "";
    }
}
