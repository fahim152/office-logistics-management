using System.ComponentModel.DataAnnotations;

namespace mlbd_logistics_management.Models;

public class Department
{
    public int Id { get; set; }

    // [Required(ErrorMessage = "Name must be given")]
    public string Name { get; set; }
    public string OfficeName { get; set; }

     public ICollection<ItemType> ItemTypes { get; }
}