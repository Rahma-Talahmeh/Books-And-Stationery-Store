using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.DTO
{
    public class Filter
    {
        public string? bTitle { get; set; }
        public string? aName { get; set; }
        public string? cName { get; set; }

        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? AuthorName { get; set; }
        public string? CategoryName { get; set; }
    }
}
