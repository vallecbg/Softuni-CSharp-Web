using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Models
{
    public class ReceiptOrder
    {
        public string Id { get; set; }

        public string ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
