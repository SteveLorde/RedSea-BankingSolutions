using redsea_api.Services.Commands;

namespace redsea_api.Services.Authentication.Commands;

public class CheckUserExistsCommand(string userId) : ICommand<bool>
{
    public string UserId { get; set; }

    public DateTime TimeStamp { get; set; } = DateTime.Now;

    public Guid CallerId { get; set; } = Guid.NewGuid();
}
