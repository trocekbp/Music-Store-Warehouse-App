﻿// <auto-generated />
using System;
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("SupplierId")
                        .IsUnique();

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

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("DocumentId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.DocumentInstrument", b =>
                {
                    b.Property<int>("DocumentInstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentInstrumentId"));

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DocumentInstrumentId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("InstrumentId");

                    b.ToTable("DocumentInstrument");
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

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.InstrumentInventory", b =>
                {
                    b.Property<int>("InstrumentInventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentInventoryId"));

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InstrumentInventoryId");

                    b.HasIndex("InstrumentId")
                        .IsUnique();

                    b.ToTable("InstrumentInventory");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Address", b =>
                {
                    b.HasOne("Music_Store_Warehouse_App.Models.Supplier", "Supplier")
                        .WithOne("Address")
                        .HasForeignKey("Music_Store_Warehouse_App.Models.Address", "SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.DocumentInstrument", b =>
                {
                    b.HasOne("Music_Store_Warehouse_App.Models.Document", "Document")
                        .WithMany("DocumentInstruments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Music_Store_Warehouse_App.Models.Instrument", "Instrument")
                        .WithMany()
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Instrument");
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
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.SetNull);

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

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.InstrumentInventory", b =>
                {
                    b.HasOne("Music_Store_Warehouse_App.Models.Instrument", "Instrument")
                        .WithOne("Inventory")
                        .HasForeignKey("Music_Store_Warehouse_App.Models.InstrumentInventory", "InstrumentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Category", b =>
                {
                    b.Navigation("Instruments");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Document", b =>
                {
                    b.Navigation("DocumentInstruments");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.FeatureDefinition", b =>
                {
                    b.Navigation("InstrumentFeatures");
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Instrument", b =>
                {
                    b.Navigation("InstrumentFeatures");

                    b.Navigation("Inventory")
                        .IsRequired();
                });

            modelBuilder.Entity("Music_Store_Warehouse_App.Models.Supplier", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Instruments");
                });
#pragma warning restore 612, 618
        }
    }
}
