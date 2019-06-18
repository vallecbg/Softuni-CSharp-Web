using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Models
{
    public class Receipt
    {
        public Receipt()
        {
            ReceiptOrders = new HashSet<ReceiptOrder>();
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public ICollection<ReceiptOrder> ReceiptOrders { get; set; }

        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
