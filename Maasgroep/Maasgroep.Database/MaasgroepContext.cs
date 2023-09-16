using Microsoft.EntityFrameworkCore;

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
			modelBuilder.Entity<Photo>().Property(c => c.Id).HasDefaultValueSql("nextval('photos.\"PhotosSeq\"')");
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
			modelBuilder.Entity<Store>().HasIndex(c => c.Name).IsUnique();
			modelBuilder.Entity<Store>().Property(c => c.Id).HasDefaultValueSql("nextval('receipts.\"StoreSeq\"')");
		}

		private void CreateReceipt(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Receipt>().ToTable("Receipts", "receipts");
			modelBuilder.HasSequence<long>("ReceiptsSeq", schema: "receipts").StartsAt(1).IncrementsBy(1);
			modelBuilder.Entity<Receipt>().Property(r => r.Created).HasDefaultValueSql("now()");
			modelBuilder.Entity<Receipt>().Property(c => c.Id).HasDefaultValueSql("nextval('receipts.\"ReceiptsSeq\"')");
		}
	}
}
