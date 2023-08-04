using mlbd_logistics_management.Models;
using System.Collections.Generic;

namespace mlbd_logistics_management.Services
{
    public interface IItemTypeService
    {
        List<ItemType> GetAllItemTypes();
        ItemType GetItemTypeById(int id);
        void CreateItemType(ItemType itemType);
        void UpdateItemType(ItemType itemType);
        void DeleteItemType(int id);
    }
}
