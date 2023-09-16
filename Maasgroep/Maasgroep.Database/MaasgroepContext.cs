using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Maasgroep.Database
{
	public class MaasgroepContext : DbContext
	{
		public DbSet<Receipt> Receipts { get; set; }
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<CostCentre> CostCentres { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("UserID=postgres;Password=postgres;Host=localhost;port=5432;Database=Maasgroep;Pooling=true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{			
			CreateCostCentre(modelBuilder);
			CreateStore(modelBuilder);			
			CreateReceipt(modelBuilder);
			CreatePhoto(modelBuilder);
		}

		private void CreatePhoto(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Photo>().ToTable("Photos", "photos");
			modelBuilder.HasSequence<long>("PhotosSeq", schema: "photos").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<Photo>().Property(p => p.Created).HasDefaultValueSql("now()");
			modelBuilder.Entity<Photo>().Property(p => p.Id).HasDefaultValueSql("nextval('photos.\"PhotosSeq\"')");
		}

		private void CreateCostCentre(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CostCentre>().ToTable("CostCentre", "receipts");
			modelBuilder.HasSequence<long>("CostCentreSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<CostCentre>().HasIndex(c => c.Name).IsUnique();
			modelBuilder.Entity<CostCentre>().Property(c => c.Id).HasDefaultValueSql("nextval('receipts.\"CostCentreSeq\"')");
			modelBuilder.Entity<CostCentre>().HasOne(c => c.Receipt).WithOne().HasForeignKey<Receipt>(r => r.CostCentreId).OnDelete(DeleteBehavior.NoAction);
		}

		private void CreateStore(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Store>().ToTable("Store", "receipts");
			modelBuilder.HasSequence<long>("StoreSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<Store>().HasIndex(s => s.Name).IsUnique();
			modelBuilder.Entity<Store>().Property(s => s.Id).HasDefaultValueSql("nextval('receipts.\"StoreSeq\"')");
			//modelBuilder.Entity<Store>().HasOne(s => s.Receipt).WithOne().HasForeignKey<Receipt>(r => r.StoreId).OnDelete(DeleteBehavior.NoAction);
		}

		private void CreateReceipt(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Receipt>().ToTable("Receipts", "receipts");
			modelBuilder.HasSequence<long>("ReceiptsSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<Receipt>().Property(r => r.Created).HasDefaultValueSql("now()");
			modelBuilder.Entity<Receipt>().Property(r => r.Id).HasDefaultValueSql("nextval('receipts.\"ReceiptsSeq\"')");
			//modelBuilder.Entity<Receipt>().HasOne(r => r.Store).WithOne().HasForeignKey<Store>(s => s.StoreId).OnDelete(DeleteBehavior.NoAction).IsRequired();
			//modelBuilder.Entity<Receipt>().HasOne(r => r.Store).WithOne().HasForeignKey<Store>(s => s.Id).IsRequired();
			//modelBuilder.Entity<Receipt>().HasOne(r => r.CostCentre).WithOne().HasForeignKey<CostCentre>(c => c.Id).OnDelete(DeleteBehavior.NoAction).IsRequired();
		}
	}
}
