using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Commands;
using redsea_database;
using redsea_database.BankingModels;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Banking.Commands;

public class GetClientGeneralFinancesCommandHandler(ReadOnlyDataContext readOnlyDataContext)
    : ICommandHandler<GetClientGeneralFinancesCommand, ClientGeneralFinances>
{
    private readonly ReadOnlyDataContext _readOnlyDataContext = readOnlyDataContext;

    public async Task<ClientGeneralFinances> HandleAsync(GetClientGeneralFinancesCommand command)
    {
        List<Account> clientAccounts = await _readOnlyDataContext.Accounts.Where(c => c.Id == command.CallerId)
            .Include(i => i.Certificates).ToListAsync();

        decimal balance = 0;

        decimal certificatesBalance = 0;

        decimal loansBalance = 0;

        foreach (Account account in clientAccounts)
        {
            balance += account.Balance;
            certificatesBalance += account.Certificates.Sum(certificate => certificate.CertValue);
        }

        ClientGeneralFinances result = new(
            command.CallerId,
            balance,
            certificatesBalance
        );

        return result;
    }
}
