using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUSACA.Data;
using MUSACA.Models;

namespace MUSACA.Services
{
    public class ProductService : IProductService
    {
        private readonly MUSACADbContext context;

        public ProductService(MUSACADbContext musacaDbContext)
        {
            this.context = musacaDbContext;
        }

        public Product CreateProduct(Product product)
        {
            product = this.context.Products.Add(product).Entity;
            this.context.SaveChanges();

            return product;
        }

        public ICollection<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
    }
}
