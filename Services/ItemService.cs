using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mlbd_logistic_management.Data;
using mlbd_logistic_management.Services.EmailSender;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.ViewModels;

namespace mlbd_logistics_management.Services
{
    public class ItemService : IItemService
    {
        private readonly MlbdLogisticManagementContext _context;
        private readonly EmailSender _emailSender;
        private readonly IPaginationService _paginationService;
        public ItemService(MlbdLogisticManagementContext context, EmailSender emailSender, IPaginationService paginationService)
        {
            _context = context;
            _emailSender = emailSender;
            _paginationService = paginationService;
        }

        public Task<PaginatedList<Item>> GetAllItems(int pageNumber, int pageSize)
        {
            var query = _context.Items.AsQueryable(); // Replace with your data source
            
            return _paginationService.PaginateAsync(query, pageNumber, pageSize);
        }

        public Item GetItemById(int id)
        {
            return _context.Items
            .Include(item => item.ItemType) // Eager-load the ItemType
            .ThenInclude(itemType => itemType.Department) // Eager-load the Department within ItemType
            .FirstOrDefault(item => item.Id == id);
        }

        public async void CreateItem(Item item)
        {
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;

            _context.Items.Add(item);
            _context.SaveChanges();
            // sent email from here, will create and event in future to send it
            var email = "fahim152@gmail.com";
            var subject = "Test";
            var body = "Hello from logistic";

            await _emailSender.SendEmailAsync(email, subject, body);
            
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
