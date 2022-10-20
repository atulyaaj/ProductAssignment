using Microsoft.EntityFrameworkCore;
using ProductAssignmentDAL.Data;
using ProductAssignmentEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductAssignmentDAL.Repository
{
    public class ProductRepository:IProductRepository
    {
        ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        private static int channel1Code = 001;
        private static long channel3Code = 10000000;
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public void GenerateProductCode(Product product, out string code)
        {
            code = GetCode(product);
            while (CheckIfUnique(code))
            {
                code = GetCode(product);
            }
        }
        private string GetCode(Product product)
        {
            string code;
            switch (product.ChannelId)
            {
                case 1:
                    code = $"{product.ProductYear}00{channel1Code}";
                    channel1Code++;
                    break;

                case 2:
                    code = AlphanumericGenerator(6);
                    break;

                case 3:
                    code = $"{channel3Code}";
                    channel3Code++;
                    break;

                default: 
                    code = "Invalid Code"; 
                    break;
            }
            return code;
        }
        private bool CheckIfUnique(string code)
        {
            return _productDbContext.products.Any(x => x.ProductCode == code);
        }
        private string AlphanumericGenerator(int length)
        {
            var result = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        public void AddProduct(Product product)
        {
            _productDbContext.products.Add(product);
            _productDbContext.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _productDbContext.products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productDbContext.products.ToList();
        }
    }
}
