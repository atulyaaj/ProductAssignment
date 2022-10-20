using ProductAssignmentEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAssignmentDAL.Repository
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductById(int productId);
        IEnumerable<Product> GetProducts();
        void GenerateProductCode(Product product, out string productCode);
    }
}
