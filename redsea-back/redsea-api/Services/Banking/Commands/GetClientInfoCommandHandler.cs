using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Commands;
using redsea_database;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Banking.Commands;

public class GetClientInfoCommandHandler(ReadOnlyDataContext readOnlyDataContext) : ICommandHandler<GetClientInfoCommand, ClientInfo>
{
    private readonly ReadOnlyDataContext _readOnlyDataContext = readOnlyDataContext;

    public async Task<ClientInfo> HandleAsync(GetClientInfoCommand command)
    {
        var result = await _readOnlyDataContext.Clients.FirstAsync(c => c.Id == command.CallerId);

        var clientInfoResult = new ClientInfo(result.Name, result.Work, result.PhoneNumber, result.Email);

        return clientInfoResult;
    }
}
