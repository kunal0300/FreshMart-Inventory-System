namespace FreshMartPortal.Models
{
    public class CheckoutRecord
    {
        public int CheckoutRecordId { get; set; }

        public int StockItemId { get; set; }

        public string ProductTitle { get; set; } = "";

        public int QuantitySold { get; set; }

        public decimal SalePrice { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}