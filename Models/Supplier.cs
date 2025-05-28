using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Diagnostics.Metrics;

namespace Music_Store_Warehouse_App.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        // Klucz obcy
        public int AddressId { get; set; }

        // Nawigacja
        [ValidateNever]
        public Address Address { get; set; }

        // Relacja 1:n — Dostawca ma wiele instrumentów
        public ICollection<Instrument> Instruments { get; set; }
    }

}
