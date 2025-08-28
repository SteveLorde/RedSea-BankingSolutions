using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Commands;
using redsea_database;

namespace redsea_api.Services.Authentication.Commands;

public class CheckUserExistsCommandHandler(ReadOnlyDataContext readOnlyDataContext) : ICommandHandler<CheckUserExistsCommand, bool>
{
    private readonly ReadOnlyDataContext _readOnlyDataContext = readOnlyDataContext;

    public async Task<bool> HandleAsync(CheckUserExistsCommand command)
    {
        bool result = await _readOnlyDataContext.Clients.AsNoTracking().AnyAsync(c => c.Id == Guid.Parse(command.UserId));

        return result;
    }
}
