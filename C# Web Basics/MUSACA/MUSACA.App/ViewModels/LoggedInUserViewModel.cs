using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.App.ViewModels
{
    public class LoggedInUserViewModel
    {
        public ICollection<OrderViewModel> OrderViewModels { get; set; } = new List<OrderViewModel>();

        public decimal Total { get; set; }
    }
}
