using redsea_api.Services.Commands;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Banking.Commands;

public class GetClientGeneralFinancesCommand(Guid callerId) : ICommand<ClientGeneralFinances>
{
    public DateTime TimeStamp { get; set; } = DateTime.Now;
    public Guid CallerId { get; set; } = callerId;
}