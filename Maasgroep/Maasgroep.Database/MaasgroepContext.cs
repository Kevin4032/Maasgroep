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
			
			modelBuilder.Entity<Photo>().ToTable("Photos", "photos");
			modelBuilder.HasSequence<long>("Photos", schema: "photos").StartsAt(1).IncrementsBy(1);

			modelBuilder.UseKeySequences("Seq");
			modelBuilder.HasDefaultSchema("receipts");
			modelBuilder.Entity<CostCentre>().HasIndex(c => c.Name).IsUnique();
			modelBuilder.Entity<Store>().HasIndex(c => c.Name).IsUnique();
			modelBuilder.Entity<Photo>().Property(p => p.Created).HasDefaultValueSql("now()");
			modelBuilder.Entity<Receipt>().Property(r => r.Created).HasDefaultValueSql("now()");



			base.OnModelCreating(modelBuilder);
		}
	}
}
