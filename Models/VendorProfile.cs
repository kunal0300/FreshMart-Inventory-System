using System.ComponentModel.DataAnnotations;

namespace FreshMartPortal.Models
{
    public class VendorProfile
    {
        public int VendorProfileId { get; set; }

        [Required]
        public string VendorName { get; set; } = "";

        public string ContactPerson { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string EmailAddress { get; set; } = "";

        public string SupplyCategory { get; set; } = "";
    }
}