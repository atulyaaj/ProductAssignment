using Microsoft.EntityFrameworkCore;
using ProductAssignmentEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAssignmentDAL.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Colour> colours { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Article> articles { get; set; }

        public void GenerateProductCode(Product product, out string productCode)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2125;Initial Catalog=ProductDb;Integrated Security=True;");
        }
    }
}
