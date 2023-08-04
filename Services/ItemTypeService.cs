
using Microsoft.EntityFrameworkCore;
using mlbd_logistic_management.Data;
using mlbd_logistics_management.Models;

namespace mlbd_logistics_management.Services
{
    public class ItemTypeService
    {
        private readonly MlbdLogisticManagementContext _context;

        public ItemTypeService(MlbdLogisticManagementContext context)
        {
            _context = context;
        }

        public List<ItemType> GetAllItemTypes()
        {
            return _context.ItemTypes.ToList();
        }

        public ItemType GetItemTypeById(int id)
        {
            return _context.ItemTypes
            .Include(item => item.Department)
            .FirstOrDefault(item => item.Id == id);
                
        }

        public void CreateItemType(ItemType itemType)
        {
            itemType.CreatedAt = DateTime.Now;
            itemType.UpdatedAt = DateTime.Now;

            _context.ItemTypes.Add(itemType);
            _context.SaveChanges();
        }

        public void UpdateItemType(ItemType itemType)
        {
            var existingItemType = _context.ItemTypes.FirstOrDefault(item => item.Id == itemType.Id);

            if (existingItemType == null)
            {
                throw new ArgumentException("Item type not found.");
            }

            existingItemType.Name = itemType.Name;
            existingItemType.DepartmentId = itemType.DepartmentId;
            existingItemType.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }

        public void DeleteItemType(int id)
        {
            var itemType = _context.ItemTypes.FirstOrDefault(item => item.Id == id);

            if (itemType == null)
            {
                throw new ArgumentException("Item type not found.");
            }

            _context.ItemTypes.Remove(itemType);
            _context.SaveChanges();
        }
    }
}
