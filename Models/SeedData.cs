
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Music_Store_Warehouse_App.Data;
using System;
using System.Linq;

namespace Music_Store_Warehouse_App.Models
{

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Music_Store_Warehouse_AppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Music_Store_Warehouse_AppContext>>()))
            {
                // Sprawdzamy czy jest jaki kolwiek instrument.
                if (context.Instrument.Any())
                {
                    return;   // DB has been seeded
                }
                // 1) Kategorie
                context.Category.AddRange(
                    new Category { Name = "Gitary" },
                    new Category { Name = "Perkusje" },
                    new Category {  Name = "Pianina" }
                );
                context.SaveChanges();

                // 2) FeatureDefinitions
                context.FeatureDefinition.AddRange(
                    new FeatureDefinition { Type = FType.Gitary , Name = "Ilość strun" },
                    new FeatureDefinition { Type = FType.Gitary, Name = "Materiał korpusu" },
                    new FeatureDefinition { Type = FType.Perkusje, Name = "Typ naciągu" },
                    new FeatureDefinition { Type = FType.Perkusje, Name = "Wielkość bębna" },
                    new FeatureDefinition { Type = FType.Pianina, Name = "Wykończenie" },
                    new FeatureDefinition { Type = FType.Pianina, Name = "Funkcja wyciszania" }
                );
                context.SaveChanges();
    
                // 3) Dostawcy
                context.Supplier.AddRange(
                    new Supplier { Name = "MuzyczneABC", Email = "kontakt@muzyczneabc.pl" },
                    new Supplier { Name = "GitaraPro", Email = "sprzedaz@gitarapro.pl" }
                );
                context.SaveChanges();

                // 3) Adresy dostawców
                context.Address.AddRange(
                    new Address { Street = "ul. Muzyczna 1", City = "Warszawa", PostalCode = "00-001", SupplierId = 1 },
                    new Address { Street = "ul. Gitarska 5", City = "Kraków", PostalCode = "30-002", SupplierId = 2 }
                );
                context.SaveChanges();

                //5) Instrumenty.
                context.Instrument.AddRange(
                   new Instrument
                   {
                       Name = "Fender Stratocaster",
                       Price = 3999.00m,
                       Description = "Legendarny gitarowy klasyk",
                       EAN = "0123456789012",
                       SKU = "FSTRAT2025",
                       Quantity = 100,
                       SupplierId = 1,
                       CategoryId = 1
                   },
                   new Instrument
                   {
                       Name = "Yamaha Stage Custom",
                       Price = 2599.00m,
                       Description = "Perkusja akustyczna 5-elementowa",
                       EAN = "0987654321098",
                       SKU = "YSTAGE2025",
                       Quantity = 100,
                       SupplierId = 2,
                       CategoryId = 2
                   }
                );
                context.SaveChanges();
                // 6) InstrumentFeatures 
                context.InstrumentFeature.AddRange(
                    new InstrumentFeature { InstrumentId = 1, FeatureDefinitionId = 1, Value = "6" },
                    new InstrumentFeature { InstrumentId = 1, FeatureDefinitionId = 2, Value = "Olcha" },
                    new InstrumentFeature { InstrumentId = 2, FeatureDefinitionId = 3, Value = "Naciąg akustyczny" }
                );
                context.SaveChanges();
            }
        }
    }
}
