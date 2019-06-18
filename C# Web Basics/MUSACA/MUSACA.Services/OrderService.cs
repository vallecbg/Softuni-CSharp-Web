using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUSACA.Data;
using MUSACA.Models;

namespace MUSACA.Services
{
    public class OrderService : IOrderService
    {
        private readonly MUSACADbContext context;

        public OrderService(MUSACADbContext musacaDbContext)
        {
            this.context = musacaDbContext;
        }

        public Order CreateOrder(Order order)
        {
            order = this.context.Orders.Add(order).Entity;
            this.context.SaveChanges();

            return order;
        }

        public Product GetProductFromBarcode(string barcode)
        {
            var product = context.Products.FirstOrDefault(x => x.Barcode.Equals(barcode));

            return product;
        }

        public User GetCashier(string username)
        {
            return this.context.Users.Single(x => x.Username.Equals(username));
        }

    }
}
