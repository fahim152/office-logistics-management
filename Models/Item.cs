namespace mlbd_logistics_management.Models
{
    public class Item 
    {
        public string Name  { get; set; }
        public string Type  { get; set; }
        public string Quantity { get; set; }
        public bool IsAssignable { get; set; }

    }
}