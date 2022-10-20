using ProductAssignmentDAL.Data;
using ProductAssignmentDAL.Repository;
using ProductAssignmentEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductAssignmentBAL.Services
{
    public class ProductService
    {
        IProductRepository _productRepository;
        ProductDbContext _productDbContext;
        public ProductService(IProductRepository productRepository, ProductDbContext productDbContext)
        {
            _productRepository = productRepository;
            _productDbContext = productDbContext;
        }
        public void AddProduct(Product product)
        {
            string productCode = string.Empty;
            _productRepository.GenerateProductCode(product, out productCode);
            product.ProductCode = productCode;
            _productDbContext.products.Add(product);
            _productDbContext.SaveChangesAsync();
            
        }
        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }


       
    }
}
