using redsea_api.Services.Commands;

namespace redsea_api.Services.Banking.Commands;

public class SaveDepositCommand : ICommand<bool>
{
    public Guid AccountId { get; set; }

    public decimal Amount { get; set; }

    public DateTime TimeStamp { get; set; }

    public Guid CallerId { get; set; }
}
