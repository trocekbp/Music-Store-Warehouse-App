﻿namespace Music_Store_Warehouse_App.Models
{
    public enum FType //Feature Type - Typ na podstawie jego dobieramy właściwości dla odpowiednich instrumentów
    {
        Gitary,
        Perkusje,
        Pianina,
        Inne        //narazie inne są nieobsłużone
    }
    public class FeatureDefinition
    {
        public int FeatureDefinitionId { get; set; }

        public FType Type { get; set; } //Typ 
        public string Name { get; set; } // np. "Ilość strun"
       
        public ICollection<InstrumentFeature> InstrumentFeatures { get; set; }
    }
}
