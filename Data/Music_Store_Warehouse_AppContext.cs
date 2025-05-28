using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Music_Store_Warehouse_App.Models;

namespace Music_Store_Warehouse_App.Data
{
    public class Music_Store_Warehouse_AppContext : DbContext
    {
        public Music_Store_Warehouse_AppContext(DbContextOptions<Music_Store_Warehouse_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Instrument> Instrument { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Supplier> Supplier { get; set; } = default!;
        public DbSet<Address> Address { get; set; } = default!;
        public DbSet<FeatureDefinition> FeatureDefinition { get; set; } = default!;
        public DbSet<InstrumentFeature> InstrumentFeature { get; set; } = default!;

    }

}
