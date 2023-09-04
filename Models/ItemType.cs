using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mlbd_logistics_management.Models;

 public class ItemType
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Foreign key relationship with the Department table
    public int DepartmentId { get; set; }
    
    public Department? Department { get; set; }

    public ICollection<Item>? Items { get; }
    // Soft delete properties
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}