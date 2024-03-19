using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Core.Entities;

using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly StoreContext _storeContext;

        public ProductsController(ILogger<ProductsController> logger,StoreContext storeContext)
        {
            _logger = logger;
            _storeContext = storeContext;

        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
                var products = await _storeContext.Products.ToListAsync();
                return products;
        }
        
        [HttpGet("{Id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            return await _storeContext.Products.FindAsync(id);
        }
        
       
    }
}