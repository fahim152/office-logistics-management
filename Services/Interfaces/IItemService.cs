using Microsoft.AspNetCore.Mvc;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.ViewModels;
using System.Collections.Generic;

namespace mlbd_logistics_management.Services
{
    public interface IItemService
    {
        Task<PaginatedList<Item>> GetAllItems(int pageNumber, int pageSize);
        Item GetItemById(int id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}
