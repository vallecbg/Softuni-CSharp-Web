using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.App.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
