using Microsoft.EntityFrameworkCore;
using redsea_api.Data.Models;

namespace redsea_api.Data;

public class DataContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("PLACEHOLDER");
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Client>()
			.HasMany(c => c.Accounts)
			.WithOne(a => a.Client)
			.HasForeignKey(a => a.ClientId);
	}
	
	public DbSet<Client> Clients { get; set; }
	public DbSet<Account> Accounts { get; set; }
	public DbSet<Certificate> Certificates { get; set; }
}