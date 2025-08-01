using Microsoft.EntityFrameworkCore;
using redsea_database.BankingModels;

namespace redsea_database;

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
		
		modelBuilder.Entity<Client>().HasData(
			new Client { Id = Guid.Parse("1"), Name = "John Doe", Work = "Software Engineer", PhoneNumber = "123456789", Email = "Bank@gmail.com" }
		);

		// Seed data for Account
		modelBuilder.Entity<Account>().HasData(
			new Account { Id = Guid.NewGuid(), AccNumber = "ACC123",Balance = 50000, ClientId = Guid.Parse("1") }
		);
	}
	
	public required DbSet<Client> Clients { get; set; }
	public required DbSet<Account> Accounts { get; set; }
	public required DbSet<Certificate> Certificates { get; set; }
}