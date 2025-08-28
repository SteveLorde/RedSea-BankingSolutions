using System.Windows.Input;

namespace redsea_api.Services.Commands;

public interface ICommandDispatcher
{
    Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
}
