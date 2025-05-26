using System.ComponentModel.DataAnnotations;

namespace Music_Store_Warehouse_App.Models
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        // Kod kreskowy – do skanowania lub importu z producenta
        [RegularExpression(@"^\d{13}$", ErrorMessage = "EAN musi zawierać dokładnie 13 cyfr")]
        public string EAN { get; set; }

        // Numer magazynowy – do zarządzania wewnętrznego
        [StringLength(20)]
        public string SKU { get; set; }

        // Numer seryjny – unikalny dla egzemplarza 
        [StringLength(30)]
        public string SerialNumber { get; set; }

        // Relacja do dostawcy (jeśli istnieje)
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        // Relacja do kategorii (opcjonalnie)
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        // Nawigacja do przypisanych cech
        public ICollection<InstrumentFeature> InstrumentFeatures { get; set; }
    }


}
