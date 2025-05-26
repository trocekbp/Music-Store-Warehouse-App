namespace Music_Store_Warehouse_App.Models
{
    public class InstrumentFeature
    {
        public int InstrumentFeatureId { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public int FeatureDefinitionId { get; set; }
        public FeatureDefinition FeatureDefinition { get; set; }

        public string Value { get; set; } // np. "Olcha"
    }

}
