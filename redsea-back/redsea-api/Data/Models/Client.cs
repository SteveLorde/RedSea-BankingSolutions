namespace redsea_api.Data.Models;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Account> Accounts { get; set; }
}