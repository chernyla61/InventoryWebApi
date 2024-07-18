using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryWebApi.DTO;
using InventoryWebApi.Models;
using InventoryWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [ApiController]
    [Route("inventory/item")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewItem([FromBody] CreateForm createForm)
        {
            var item = await _inventoryService.CreateItem(createForm);
            return CreatedAtAction(nameof(GetItemByBarcode), new { barcode = item.Barcode }, item);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItemByBarcode([FromBody] int barcode)
        {
            await _inventoryService.DeleteItem(barcode);
            return NoContent();
        }

        [HttpPut("{barcode}")]
        public async Task<IActionResult> EditItem(int barcode, [FromBody] CreateForm updateForm)
        {
            try
            {
                await _inventoryService.UpdateItem(barcode, updateForm);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _inventoryService.GetItems();
            return Ok(items);
        }

        [HttpGet("query")]
        public async Task<IActionResult> GetItemsByQuery([FromQuery] string category, [FromQuery] int? barcode, [FromQuery] string name, [FromQuery] double? discount)
        {
            var queryModel = new ItemQueryModel
            {
                Category = category,
                Barcode = barcode,
                Name = name,
                Discount = discount
            };

            var items = await _inventoryService.GetItemsByQuery(queryModel);
            return Ok(items);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> GetItemsSortedByPrice()
        {
            var items = await _inventoryService.GetSortedItems();
            return Ok(items);
        }

        [HttpGet("{barcode}")]
        public async Task<IActionResult> GetItemByBarcode(int barcode)
        {
            var queryModel = new ItemQueryModel { Barcode = barcode };
            var items = await _inventoryService.GetItemsByQuery(queryModel);
            return Ok(items);
        }
    }
}
