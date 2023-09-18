﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Maasgroep.Database
{
	public class MaasgroepContext : DbContext
	{
		public DbSet<Receipt> Receipt { get; set; }
		public DbSet<ReceiptApproval> ReceiptApproval { get; set; }
		public DbSet<ReceiptStatus> ReceiptStatus { get; set; }
		public DbSet<Photo> Photo { get; set; }
		public DbSet<Store> Store { get; set; }
		public DbSet<CostCentre> CostCentre { get; set; }
		public DbSet<MaasgroepMember> MaasgroepMember { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("UserID=postgres;Password=postgres;Host=localhost;port=5432;Database=Maasgroep;Pooling=true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{			
			CreateCostCentre(modelBuilder);
			CreateStore(modelBuilder);
			CreateReceiptApproval(modelBuilder);
			CreateReceiptStatus(modelBuilder);
			CreateReceipt(modelBuilder);
			CreatePhoto(modelBuilder);
			CreateMaasgroepMember(modelBuilder);
		}

		private void CreatePhoto(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Photo>().ToTable("Photo", "photos");
			modelBuilder.HasSequence<long>("PhotoSeq", schema: "photos").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<Photo>().Property(p => p.Created).HasDefaultValueSql("now()");
			modelBuilder.Entity<Photo>().Property(p => p.Id).HasDefaultValueSql("nextval('photos.\"PhotoSeq\"')");
		}

		private void CreateCostCentre(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CostCentre>().ToTable("CostCentre", "receipts");
			modelBuilder.HasSequence<long>("CostCentreSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<CostCentre>().HasIndex(c => c.Name).IsUnique();
			modelBuilder.Entity<CostCentre>().Property(c => c.Id).HasDefaultValueSql("nextval('receipts.\"CostCentreSeq\"')");
		}

		private void CreateStore(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Store>().ToTable("Store", "receipts");
			modelBuilder.HasSequence<long>("StoreSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<Store>().HasIndex(s => s.Name).IsUnique();
			modelBuilder.Entity<Store>().Property(s => s.Id).HasDefaultValueSql("nextval('receipts.\"StoreSeq\"')");
		}

		private void CreateReceipt(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Receipt>().ToTable("Receipt", "receipts");
			modelBuilder.HasSequence<long>("ReceiptSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<Receipt>().Property(r => r.Created).HasDefaultValueSql("now()");
			modelBuilder.Entity<Receipt>().Property(r => r.Id).HasDefaultValueSql("nextval('receipts.\"ReceiptSeq\"')");
		}

		private void CreateReceiptApproval(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ReceiptApproval>().ToTable("Approval", "receipts");
			modelBuilder.HasSequence<long>("ReceiptApprovalSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<ReceiptApproval>().Property(r => r.Approved).HasDefaultValueSql("now()");
		}

		private void CreateReceiptStatus(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ReceiptStatus>().ToTable("Status", "receipts");
			modelBuilder.HasSequence<short>("ReceiptStatusSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<ReceiptStatus>().Property(r => r.Id).HasDefaultValueSql("nextval('receipts.\"ReceiptStatusSeq\"')");
		}

		private void CreateMaasgroepMember(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MaasgroepMember>().ToTable("Member", "admin");
			modelBuilder.HasSequence<long>("MemberSeq", schema: "admin").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<MaasgroepMember>().Property(m => m.Id).HasDefaultValueSql("nextval('admin.\"MemberSeq\"')");
			modelBuilder.Entity<MaasgroepMember>().HasIndex(m => m.Name).IsUnique();
		}
	}
}
