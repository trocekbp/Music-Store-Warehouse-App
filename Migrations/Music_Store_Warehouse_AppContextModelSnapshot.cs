﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Music_Store_Warehouse_App.Data;

#nullable disable

namespace Music_Store_Warehouse_App.Migrations
{
    [DbContext(typeof(Music_Store_Warehouse_AppContext))]
    partial class Music_Store_Warehouse_AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.FeatureDefinition", b =>
                {
                    b.Property<int>("FeatureDefinitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureDefinitionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("FeatureDefinitionId");

                    b.ToTable("FeatureDefinition");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("InstrumentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.InstrumentFeature", b =>
                {
                    b.Property<int>("InstrumentFeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentFeatureId"));

                    b.Property<int>("FeatureDefinitionId")
                        .HasColumnType("int");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentFeatureId");

                    b.HasIndex("FeatureDefinitionId");

                    b.HasIndex("InstrumentId");

                    b.ToTable("InstrumentFeature");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Instrument", b =>
                {
                    b.HasOne("Music_Store_Warehouse_App.Models.Category", "Category")
                        .WithMany("Instruments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Music_Store_Warehouse_App.Models.Supplier", "Supplier")
                        .WithMany("Instruments")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.InstrumentFeature", b =>
                {
                    b.HasOne("Music_Store_Warehouse_App.Models.FeatureDefinition", "FeatureDefinition")
                        .WithMany("InstrumentFeatures")
                        .HasForeignKey("FeatureDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Music_Store_Warehouse_App.Models.Instrument", "Instrument")
                        .WithMany("InstrumentFeatures")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureDefinition");

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Supplier", b =>
                {
                    b.HasOne("Music_Store_Warehouse_App.Models.Address", "Address")
                        .WithOne("Supplier")
                        .HasForeignKey("Music_Store_Warehouse_App.Models.Supplier", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Address", b =>
                {
                    b.Navigation("Supplier")
                        .IsRequired();
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Category", b =>
                {
                    b.Navigation("Instruments");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.FeatureDefinition", b =>
                {
                    b.Navigation("InstrumentFeatures");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Instrument", b =>
                {
                    b.Navigation("InstrumentFeatures");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Supplier", b =>
                {
                    b.Navigation("Instruments");
                });
#pragma warning restore 612, 618
        }
    }
}
