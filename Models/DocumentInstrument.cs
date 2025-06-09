using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Music_Store_Warehouse_App.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Music_Store_Warehouse_App.Models
{
    public class DocumentInstrument
    {
        public int DocumentInstrumentId { get; set; }

        public int DocumentId { get; set; }

        [ValidateNever]
        public Document Document { get; set; }

        public int InstrumentId { get; set; }

        [ValidateNever]
        public Instrument Instrument { get; set; }

        [DisplayName("Ilość")]

        [Required(ErrorMessage = "Ilość jest wymagana")]
        [Range(0, int.MaxValue, ErrorMessage = "Ilość nie może być ujemna")]
        public int Quantity { get; set; }           // ilość przyjęta / wydana
    
    }
}
