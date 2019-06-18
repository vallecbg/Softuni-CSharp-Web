namespace MUSACA.Services
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }

        public string IssuedOn { get; set; }

        public decimal Total { get; set; }

        public string Cashier { get; set; }
    }
}
