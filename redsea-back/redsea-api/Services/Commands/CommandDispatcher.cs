using System.Windows.Input;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Commands;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
    {
        var handler = serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();
        
        if (handler == null)
            throw new Exception($"No handler found for command {typeof(TCommand).Name}");

        return await handler.HandleAsync(command);
    }
}