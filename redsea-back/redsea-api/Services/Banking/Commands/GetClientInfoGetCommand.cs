using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Commands;
using redsea_database;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Banking.Commands;

public class GetClientInfoGetCommand : ICommand<ClientInfo>
{
    public GetClientInfoGetCommand(Guid callerId)
    {
        TimeStamp = DateTime.Now;
        CallerId = callerId;
    }
    
    public DateTime TimeStamp { get; set; }
    public Guid CallerId { get; set; }
}