using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Models
{
    public class UserReceipt
    {
        public string Id { get; set; }

        public string CashierId { get; set; }
        public virtual User Cashier { get; set; }

        public string ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
