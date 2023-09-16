﻿// <auto-generated />
using System;
using Maasgroep.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Maasgroep.Database.Migrations
{
    [DbContext(typeof(MaasgroepContext))]
    partial class MaasgroepContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("CostCentreSeq", "receipts");

            modelBuilder.HasSequence("PhotosSeq", "photos");

            modelBuilder.HasSequence("ReceiptsSeq", "receipts");

            modelBuilder.HasSequence("StoreSeq", "receipts");

            modelBuilder.Entity("Maasgroep.Database.CostCentre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('receipts.\"CostCentreSeq\"')");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CostCentre", "receipts");
                });

            modelBuilder.Entity("Maasgroep.Database.Photo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('photos.\"PhotosSeq\"')");

                    b.Property<byte[]>("Bytes")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<long?>("ReceiptId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId");

                    b.ToTable("Photos", "photos");
                });

            modelBuilder.Entity("Maasgroep.Database.Receipt", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('receipts.\"ReceiptsSeq\"')");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Approved")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("CostCentreId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<long?>("StoreId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CostCentreId");

                    b.HasIndex("StoreId");

                    b.ToTable("Receipts", "receipts");
                });

            modelBuilder.Entity("Maasgroep.Database.Store", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('receipts.\"StoreSeq\"')");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Store", "receipts");
                });

            modelBuilder.Entity("Maasgroep.Database.Photo", b =>
                {
                    b.HasOne("Maasgroep.Database.Receipt", "Receipt")
                        .WithMany()
                        .HasForeignKey("ReceiptId");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("Maasgroep.Database.Receipt", b =>
                {
                    b.HasOne("Maasgroep.Database.CostCentre", "CostCentre")
                        .WithMany()
                        .HasForeignKey("CostCentreId");

                    b.HasOne("Maasgroep.Database.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId");

                    b.Navigation("CostCentre");

                    b.Navigation("Store");
                });
#pragma warning restore 612, 618
        }
    }
}
