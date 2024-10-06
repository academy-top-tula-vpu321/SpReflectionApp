using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHomeWorksApp
{
    internal class Author
    {
        public int Id { set; get; }
        public string Name { set; get; } = null!;
        public DateOnly? BirthDate { set; get; }

        public List<Book> Books { get; set; } = new();
    }
}
