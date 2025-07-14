namespace redsea_api.Services.Commands;

public interface ICommandBase
{
    public Guid Id { get; set; }
    
    Task<bool> Execute();
}