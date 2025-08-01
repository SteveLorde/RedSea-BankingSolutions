using Microsoft.EntityFrameworkCore;
using redsea_database.BankingModels;
using redsea_database.InvestModels;

namespace redsea_database;

public class ReadOnlyDataContext
{
    private readonly DataContext _context;
    
    public ReadOnlyDataContext(DataContext context)
    {
        _context = context;
        
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    
    // Expose read-only DbSets
    public IQueryable<Client> Clients => _context.Set<Client>().AsNoTracking();
    public IQueryable<Account> Accounts => _context.Set<Account>().AsNoTracking();
    public IQueryable<Certificate> Certificates => _context.Set<Certificate>().AsNoTracking();
    public IQueryable<StockEntity> StockEntities => _context.Set<StockEntity>().AsNoTracking();
    
    public void SaveChanges() => throw new InvalidOperationException("This context is read-only.");
}