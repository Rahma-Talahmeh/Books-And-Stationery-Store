namespace BookStore_project.Core.Models;

public class Admin
{
    public decimal AdminId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
