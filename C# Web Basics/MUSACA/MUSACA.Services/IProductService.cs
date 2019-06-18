using System;
using System.Collections.Generic;
using System.Text;
using MUSACA.Models;

namespace MUSACA.Services
{
    public interface IProductService
    {
        Product CreateProduct(Product product);

        ICollection<Product> GetAllProducts();
    }
}
