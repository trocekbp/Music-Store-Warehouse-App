using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Music_Store_Warehouse_App.Models
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Ilość jest wymagana")]
        [Range(0, int.MaxValue, ErrorMessage = "Ilość nie może być ujemna")]
        public int Quantity { get; set; }

        // Kod kreskowy – do skanowania lub importu z producenta
        [RegularExpression(@"^\d{13}$", ErrorMessage = "EAN musi zawierać dokładnie 13 znaków")]
        public string EAN { get; set; }

        // Numer magazynowy – do zarządzania wewnętrznego
        [StringLength(20)]
        public string SKU { get; set; }

        // Relacja do dostawcy, może być null we wstępnej fazie projektu
        public int? SupplierId { get; set; }

        [ValidateNever] //Dzięki temu nie będzie problemu z tworzeniem klasy, WAŻNE
        public Supplier? Supplier { get; set; }

        // Relacja do kategorii 
        [Required(ErrorMessage ="Kategoria jest wymagana")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }

        // Nawigacja do przypisanych cech
        public ICollection<InstrumentFeature>? InstrumentFeatures { get; set; }
    }

}
