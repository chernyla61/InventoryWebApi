using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryWebApi.DTO;
using InventoryWebApi.Models;
using InventoryWebApi.DataAccess;

namespace InventoryWebApi.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepository _repository;

        public InventoryService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<InventoryItem> CreateItem(CreateForm createForm)
        {
            var newItem = new InventoryItem
            {
                Name = createForm.Name,
                Category = createForm.Category,
                Price = createForm.Price,
                Discount = createForm.Discount,
                Quantity = createForm.Quantity
            };
            return await _repository.AddInventoryItem(newItem);
        }

        public async Task DeleteItem(int barcode)
        {
            var item = (await _repository.GetInventory()).FirstOrDefault(i => i.Barcode == barcode);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }
            await _repository.DeleteInventoryItem(item);
        }

        public async Task<List<InventoryItem>> GetItems()
        {
            return await _repository.GetInventory();
        }

        public async Task<List<InventoryItem>> GetItemsByQuery(ItemQueryModel queryParameters)
        {
            return await _repository.GetInventoryItem(queryParameters);
        }

        public async Task<List<InventoryItem>> GetSortedItems()
        {
            return await _repository.GetSorted();
        }

        public async Task UpdateItem(int barcode, CreateForm updateForm)
        {
            var existingItem = (await _repository.GetInventory()).FirstOrDefault(i => i.Barcode == barcode);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            existingItem.Name = updateForm.Name;
            existingItem.Category = updateForm.Category;
            existingItem.Price = updateForm.Price;
            existingItem.Discount = updateForm.Discount;
            existingItem.Quantity = updateForm.Quantity;

            await _repository.UpdateInventoryItem(existingItem);
        }
    }
}
