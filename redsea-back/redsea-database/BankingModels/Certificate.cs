namespace redsea_database.BankingModels;

public class Certificate
{
    public Guid Id { get; set; }
    public string CertName { get; set; }
    public decimal CertValue { get; set; }
    public DateTime FoundedAt { get; set; }
    
    public ICollection<Account> Accounts { get; set; }
}