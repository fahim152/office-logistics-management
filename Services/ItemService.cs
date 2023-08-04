using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mlbd_logistic_management.Data;
using mlbd_logistics_management.Models;

namespace mlbd_logistics_management.Services
{
    public class ItemService : IItemService
    {
        private readonly MlbdLogisticManagementContext _context;

        public ItemService(MlbdLogisticManagementContext context)
        {
            _context = context;
        }

        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items
            .Include(item => item.ItemType) // Eager-load the ItemType
            .ThenInclude(itemType => itemType.Department) // Eager-load the Department within ItemType
            .FirstOrDefault(item => item.Id == id);
        }

        public void CreateItem(Item item)
        {
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;

            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            var existingItem = _context.Items.FirstOrDefault(i => i.Id == item.Id);

            if (existingItem == null)
            {
                throw new ArgumentException("Item not found.");
            }

            existingItem.Name = item.Name;
            existingItem.ItemTypeId = item.ItemTypeId;
            existingItem.Quantity = item.Quantity;
            existingItem.IsAssignable = item.IsAssignable;
            existingItem.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                throw new ArgumentException("Item not found.");
            }

            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }
}
