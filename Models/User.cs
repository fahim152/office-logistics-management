using Microsoft.AspNetCore.Identity;

namespace mlbd_logistics_management.Models;

public class User : IdentityUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
