using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Music_Store_Warehouse_App.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Nawigacja odwrotna
        [ValidateNever]
        public Supplier Supplier { get; set; }
    }

}
