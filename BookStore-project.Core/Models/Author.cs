//using System;
//using System.Collections.Generic;

//namespace BookStore_project.Core.Models;

//public partial class Author
//{
//    public decimal AuthorId { get; set; }

//    public string AuthorName { get; set; } = null!;

//    public string? Bio { get; set; }

//    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
//}

//namespace BookStore_project.Core.Models
//{
//    public class Author
//    {
//        public int AuthorId { get; set; }
//        public string AuthorName { get; set; } = null!;
//        public string? Bio { get; set; }
//    }
//}
using BookStore_project.Core.Models;
//using BookStore.API.Models;

namespace BookStore_project.Core.Models
{
    public class Author
    {
        public decimal AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string? Bio { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}