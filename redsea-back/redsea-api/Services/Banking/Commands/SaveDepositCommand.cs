using redsea_api.Services.Commands;

namespace redsea_api.Services.Banking.Commands;

public class SaveDepositCommand : ICommand<bool>
{
    public DateTime TimeStamp { get; set; }
    public Guid CallerId { get; set; }
    public Guid AccountId { get; set; }
    public float Amount { get; set; }
}