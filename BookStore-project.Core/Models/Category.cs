namespace BookStore_project.Core.Models
{
    public partial class Category
    {
        public decimal CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }

        
         public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}