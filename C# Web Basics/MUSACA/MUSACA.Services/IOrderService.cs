using System;
using System.Collections.Generic;
using System.Text;
using MUSACA.Models;

namespace MUSACA.Services
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);

        Product GetProductFromBarcode(string barcode);

        //User GetCashier(string username);
    }
}
