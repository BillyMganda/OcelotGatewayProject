using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDBContext _dbContext;
        public ProductService(ProductDBContext context)
        {
            _dbContext = context;
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(Guid Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            if(filteredData != null)
            {
                _dbContext.Remove(filteredData);
                _dbContext.SaveChanges();
                return true;
            }               
            return false;
        }

        public Product GetProductById(Guid id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault()!;
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
