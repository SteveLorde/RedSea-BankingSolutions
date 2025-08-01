using redsea_database.Enums;

namespace redsea_database.GeneralModels;

public class Admin
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string HashedPassword { get; set; }
    public AdminLevel Level { get; set; }
}