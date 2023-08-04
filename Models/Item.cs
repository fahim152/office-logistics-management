namespace mlbd_logistics_management.Models;

public class Item 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ItemTypeId { get; set; }
    public ItemType? ItemType { get; set; }
    public int Quantity { get; set; }
    public bool IsAssignable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
