using redsea_api.Services.Commands;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Banking.Commands;

public class GetClientInfoCommand : ICommand<ClientInfo>
{
    public GetClientInfoCommand(Guid callerId)
    {
        TimeStamp = DateTime.Now;
        CallerId = callerId;
    }

    public DateTime TimeStamp { get; set; }

    public Guid CallerId { get; set; }
}
