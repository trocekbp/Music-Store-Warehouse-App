namespace Music_Store_Warehouse_App.Models
{
    public class FeatureDefinition
    {
        public int FeatureDefinitionId { get; set; }
        public string Name { get; set; } // np. "Ilość strun"
        public ICollection<InstrumentFeature> InstrumentFeatures { get; set; }
    }
}
