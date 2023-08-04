using mlbd_logistics_management.Models;
using System.Collections.Generic;

namespace mlbd_logistics_management.Services
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        Item GetItemById(int id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}
