using InventoryWebApi.DataAccess;
using InventoryWebApi.DTO;
using InventoryWebApi.Models;

namespace InventoryWebApi.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepository _repository;

        public InventoryService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<InventoryItem> CreateItem(CreateForm createForm)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(int barcode)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryItem>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryItem>> GetItemsByQuery(ItemQueryModel queryParameters)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryItem>> GetSortedItems()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(int barcode, CreateForm updateForm)
        {
            throw new NotImplementedException();
        }
    }

}
