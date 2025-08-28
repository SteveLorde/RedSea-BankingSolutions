using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Commands;
using redsea_database;

namespace redsea_api.Services.Banking.Commands;

public class SaveDepositCommandHandler(DataContext dataContext) : ICommandHandler<SaveDepositCommand, bool>
{
    public async Task<bool> HandleAsync(SaveDepositCommand command)
    {
        var account = await dataContext.Accounts.FirstAsync(a => a.Id == command.AccountId);

        // Note: there should be a method to convert currency
        account.Balance += command.Amount;

        await dataContext.SaveChangesAsync();

        return true;
    }
}
