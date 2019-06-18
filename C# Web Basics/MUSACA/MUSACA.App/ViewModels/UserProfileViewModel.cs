using System;
using System.Collections.Generic;
using System.Text;
using MUSACA.Services;

namespace MUSACA.App.ViewModels
{
    public class UserProfileViewModel
    {
        public IEnumerable<ReceiptViewModel> Receipts { get; set; } = new List<ReceiptViewModel>();
    }
}
