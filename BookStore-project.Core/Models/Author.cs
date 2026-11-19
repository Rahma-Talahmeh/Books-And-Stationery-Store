namespace BookStore_project.Core.Models
{
    public class Author
    {
        public decimal AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string? Bio { get; set; }

        // public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public List<Product> Products { get; set; } = new List<Product>();
    }
}