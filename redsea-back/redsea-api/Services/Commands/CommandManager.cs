namespace redsea_api.Services.Commands;

public class CommandManager
{
    private Queue<ICommandBase> _queuedCommands =  new Queue<ICommandBase>();
}