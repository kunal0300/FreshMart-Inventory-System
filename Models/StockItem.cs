using System.ComponentModel.DataAnnotations;

namespace FreshMartPortal.Models
{
    public class StockItem
    {
        public int StockItemId { get; set; }

        [Required]
        public string ItemTitle { get; set; } = "";

        [Required]
        public string Barcode { get; set; } = "";

        [Required]
        public string BrandOrSupplier { get; set; } = "";

        [Required]
        public string Department { get; set; } = "";

        public DateTime ExpiryOrRestockDate { get; set; }

        public string AvailabilityStatus { get; set; } = "Available";

        public decimal UnitCost { get; set; }

        public int UnitsAvailable { get; set; }

        public int ReorderPoint { get; set; } = 5;
    }
}