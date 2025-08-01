using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Commands;
using redsea_database;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Banking.Commands;

public class GetClientGeneralFinancesCommandHandler(ReadOnlyDataContext readOnlyDataContext) : ICommandHandler<GetClientGeneralFinancesCommand, ClientGeneralFinances>
{
    private readonly ReadOnlyDataContext _readOnlyDataContext = readOnlyDataContext;

    public async Task<ClientGeneralFinances> HandleAsync(GetClientGeneralFinancesCommand command)
    {
        var clientAccounts = await _readOnlyDataContext.Accounts.Where(c => c.Id == command.CallerId).Include(i => i.Certificates).ToListAsync();
        
        var balance = 0.0f;
        var certificatesBalance = 0.0f;
        var loansBalance = 0.0f;

        foreach (var account in clientAccounts)
        {
            balance += account.Balance;
            certificatesBalance += account.Certificates.Sum(certificate => (float)certificate.CertValue);
        }

        var result = new ClientGeneralFinances(
            command.CallerId,
            balance,
            certificatesBalance
        );

        return result;
    }
}