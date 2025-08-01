namespace redsea_database.BankingModels;

public class Client
{
    public Guid Id { get; set; }
    public string HashedPassword { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Work { get; set; }
    public ICollection<Account> Accounts { get; set; }
    
}