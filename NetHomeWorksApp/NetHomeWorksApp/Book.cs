using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHomeWorksApp
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        //public int AuthorId { get; set; }
        public Author? Author { get; set; }
        
        //public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        
        public int PublishYear {  get; set; }
        public decimal Price { get; set; }

        
    }
}
