﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly IProductService _service;
        public productsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Product> ProductList()
        {
            var productList = _service.GetProductList();
            return productList;
        }

        [HttpGet("{id}")]
        public Product GetProductById(Guid id)
        {
            return _service.GetProductById(id);
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            return _service.AddProduct(product);
        }

        [HttpPut]
        public Product UpdateProduct(Product product)
        {
            return _service.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public bool DeleteProduct(Guid id)
        {
            return _service.DeleteProduct(id);
        }
    }
}
