using System;
using System.Collections.Generic;
using System.Text;
using MUSACA.Models;
using MUSACA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace MUSACA.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService orderService;

        public OrdersController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        public ActionResult Create(string barcode, int quantity)
        {
            var product = orderService.GetProductFromBarcode(barcode);

            if (product == null)
            {
                return View();
            }

            var order = new Order
            {
                Product = product,
                Quantity = quantity,
                Cashier = orderService.GetCashier(User.Username)
            };

            this.orderService.CreateOrder(order);

            return Redirect("/");
        }
    }
}
