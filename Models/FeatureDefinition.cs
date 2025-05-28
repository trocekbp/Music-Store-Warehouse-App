namespace Music_Store_Warehouse_App.Models
{
    public enum Type //Typ na podstawie jego dobieramy właściwości dla odpowiednich instrumentów
    {
        Guitar,
        Drums,
        Piano,
        Other
    }
    public class FeatureDefinition
    {
        public int FeatureDefinitionId { get; set; }

        public Type Type { get; set; } //Typ 
        public string Name { get; set; } // np. "Ilość strun"
       
        public ICollection<InstrumentFeature> InstrumentFeatures { get; set; }
    }
}
