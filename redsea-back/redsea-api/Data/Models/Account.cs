namespace redsea_api.Data.Models;

public class Account
{
    public Guid Id { get; set; }
    public string AccNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    
    public ICollection<Certificate> Certificates { get; set; }
}