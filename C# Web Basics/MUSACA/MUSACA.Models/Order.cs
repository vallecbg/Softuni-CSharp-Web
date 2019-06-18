using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Models
{
    public class Order
    {
        public string Id { get; set; }

        public Status Status { get; set; } = Status.Active;

        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public string CashierId { get; set; }
        public virtual User Cashier { get; set; }
    }
}
