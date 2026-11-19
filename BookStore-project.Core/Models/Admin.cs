namespace BookStore_project.Core.Models
{
    public class Admin
    {
        public decimal ADMIN_ID { get; set; }
        public string USERNAME { get; set; } = string.Empty;
        public string PASSWORD_HASH { get; set; } = string.Empty;
        public string FULL_NAME { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
    }
}