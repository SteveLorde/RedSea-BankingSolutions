namespace redsea_api.Services.Commands;

public interface ICommand<TResult>
{
    public DateTime TimeStamp { get; set; }

    public Guid CallerId { get; set; }
}
