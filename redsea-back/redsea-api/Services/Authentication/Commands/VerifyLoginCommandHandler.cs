using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Commands;
using redsea_api.Services.Hash;
using redsea_database;
using redsea_database.BankingModels;

namespace redsea_api.Services.Authentication.Commands;

public class VerifyLoginCommandHandler(ReadOnlyDataContext readOnlyDataContext) : ICommandHandler<VerifyLoginCommand, bool>
{
    private readonly ReadOnlyDataContext _readOnlyDataContext = readOnlyDataContext;

    public async Task<bool> HandleAsync(VerifyLoginCommand command)
    {
        Client client = await _readOnlyDataContext.Clients.Where(c => c.Id == command.CallerId).FirstAsync();

        bool result = Hashing.VerifyHash(command.Password, client.HashedPassword, client.Salt);

        return result;
    }
}
