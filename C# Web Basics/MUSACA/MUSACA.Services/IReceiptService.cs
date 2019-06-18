using System;
using System.Collections.Generic;
using System.Text;
using MUSACA.Models;

namespace MUSACA.Services
{
    public interface IReceiptService
    {
        List<Order> ChangeOrderStatus();

        User GetCashier(string username);

        Receipt CreateReceipt(string username, List<Order> orders);

        ReceiptOrder CreateReceiptOrder(Receipt receipt, List<Order> orders);

        UserReceipt CreateUserReceipt(Receipt receipt);

        ICollection<Receipt> GetAllReceipts();
    }
}
