using System.Collections.Generic;
using System.Linq;
using MUSACA.App.ViewModels;
using MUSACA.Models;
using MUSACA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace MUSACA.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService productService;

        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        
        [Authorize]
        public ActionResult Create()
        {
            if (User == null)
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(string name, string picture, decimal price, string barcode)
        {
            //TODO: Check if I can do it with AutoMapper
            Product product = new Product
            {
                Name = name,
                Picture = picture,
                Barcode = barcode,
                Price = price
            };

            this.productService.CreateProduct(product);

            return this.Redirect("/Products/All");
        }

        [Authorize]
        public ActionResult All()
        {
            ICollection<Product> allProducts = this.productService.GetAllProducts();

            if (allProducts.Count != 0)
            {
                return this.View(allProducts.Select(ModelMapper.ProjectTo<ProductViewModel>).ToList());
            }

            return this.View(new List<ProductViewModel>());
        }
    }
}
