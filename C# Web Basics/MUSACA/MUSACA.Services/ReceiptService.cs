using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUSACA.Data;
using MUSACA.Models;

namespace MUSACA.Services
{
    public class ReceiptService : IReceiptService
    {
        public readonly MUSACADbContext context;

        public ReceiptService(MUSACADbContext musacaDbContext)
        {
            this.context = musacaDbContext;
        }

        public List<Order> ChangeOrderStatus()
        {
            var orders = context.Orders.Where(o => o.Status == Status.Active).ToList();

            orders.ForEach(o => o.Status = Status.Completed);

            return orders;
        }

        public User GetCashier(string username)
        {
            return context.Users.Single(c => c.Username.Equals(username));
        }

        public Receipt CreateReceipt(string username, List<Order> orders)
        {
            var receipt = new Receipt
            {
                Cashier = GetCashier(username),
                IssuedOn = DateTime.UtcNow
            };

            context.Orders.UpdateRange(orders);
            context.SaveChanges();

            context.Receipts.Add(receipt);
            context.SaveChanges();

            return receipt;
        }

        public ReceiptOrder CreateReceiptOrder(Receipt receipt, List<Order> orders)
        {
            var receiptOrder = new ReceiptOrder
            {
                Orders = orders,
                Receipt = receipt
            };

            context.ReceiptOrders.Add(receiptOrder);
            context.SaveChanges();

            return receiptOrder;
        }

        public UserReceipt CreateUserReceipt(Receipt receipt)
        {
            var userReceipt = new UserReceipt
            {
                Receipt = receipt,
                Cashier = receipt.Cashier
            };

            context.UserReceipts.Add(userReceipt);
            context.SaveChanges();

            

            return userReceipt;
        }

        public ICollection<Receipt> GetAllReceipts()
        {
            return context.Receipts.ToList();
        }
    }
}
