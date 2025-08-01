namespace redsea_database.BankingModels;

public class Account
{
    public Guid Id { get; set; }
    public string AccNumber { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public float Balance { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    
    public ICollection<Certificate> Certificates { get; set; }
}