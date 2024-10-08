﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHomeWorksApp
{
    internal class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? City { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
