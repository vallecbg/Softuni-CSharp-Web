using System;
using System.Linq;
using System.Threading;
using MUSACA.App.ViewModels;
using MUSACA.Models;
using MUSACA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace MUSACA.App.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly ReceiptService receiptService;
        private readonly ProductService productService;

        public ReceiptsController(ReceiptService receiptService, ProductService productService)
        {
            this.receiptService = receiptService;
            this.productService = productService;
        }

        [HttpPost]
        public ActionResult Create()
        {
            var orders = receiptService.ChangeOrderStatus();

            var receipt = receiptService.CreateReceipt(User.Username, orders);

            var receiptOrder = receiptService.CreateReceiptOrder(receipt, orders);

            var userReceipt = receiptService.CreateUserReceipt(receipt);

            //TODO: Fix it!!!
            //var products = productService.GetAllProducts();
            ;

            //receiptService.context.Entry(receiptOrder).Reload();

            //Thread.Sleep(3000);

            

            var orderViewModels = receiptOrder.Orders
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    Product = o.Product.Name,
                    Quantity = o.Quantity,
                    Price = o.Product.Price
                })
                .ToList();

            var receiptViewModel = new ReceiptDetailsViewModel
            {
                Id = receipt.Id,
                Orders = orderViewModels,
                IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy"),
                Cashier = receipt.Cashier.Username
            };

            var total = orderViewModels.Sum(ovm => ovm.Quantity * ovm.Price);

            receiptViewModel.Total = total;

            return View(receiptViewModel, "Details");
        }


        [Authorize]
        public ActionResult Details(string id)
        {
            var receiptViewModel = receiptService.context.Receipts
                .Select(r => new ReceiptDetailsViewModel
                {
                    Id = r.Id,
                    Orders = r.ReceiptOrders.SelectMany(ro => ro.Orders).Select(o => new OrderViewModel
                    {
                        Id = o.Id,
                        Product = o.Product.Name,
                        Quantity = o.Quantity,
                        Price = o.Product.Price,

                    }).ToList(),
                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy"),
                    Cashier = r.Cashier.Username
                })
                .Single(r => r.Id.Equals(id));

            receiptViewModel.Total = receiptViewModel.Orders.Sum(o => o.Price * o.Quantity);

            return View(receiptViewModel);
        }

        public ActionResult All()
        {
            var receipts = receiptService.context.Receipts
                .Select(r => new ReceiptViewModel
                {
                    Id = r.Id,
                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy"),
                    Total = r.ReceiptOrders.Select(ro => ro.Orders.Sum(o => o.Product.Price * o.Quantity)).Sum(),
                    Cashier = r.Cashier.Username
                })
                .ToList();

            var profile = new UserProfileViewModel
            {
                Receipts = receipts
            };

            return View(profile, "/Receipts/All");
        }
    }
}
