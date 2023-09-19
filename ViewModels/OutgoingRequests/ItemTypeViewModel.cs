using mlbd_logistics_management.Models;

namespace mlbd_logistics_management.ViewModels.OutgoingRequests;

public class ItemTypeViewModel  
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Foreign key relationship with the Department table
    public int DepartmentId { get; set; }
    
    public Department? Department { get; set; }

    public ICollection<ItemType>? Items { get; }
    // Soft delete properties
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
