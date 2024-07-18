using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryWebApi.DataAccess;
using InventoryWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InventoryWebApi.DTO;
using InventoryWebApi.Services;

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
        
    }

}
