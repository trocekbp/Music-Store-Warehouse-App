using System.Diagnostics.Metrics;

namespace Music_Store_Warehouse_App.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Instrument> Instruments { get; set; }
    }

}
