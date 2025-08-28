using Microsoft.AspNetCore.Mvc;
using redsea_api.Services.Authentication;
using redsea_api.Services.Authentication.Commands;
using redsea_api.Services.Commands;

namespace redsea_api.Controllers;

public class AccountController(CommandDispatcher commandDispatcher) : BaseController
{
    private readonly CommandDispatcher _commandDispatcher = commandDispatcher;

    [HttpPost("account/checkuser")]
    public async Task<IActionResult> GetClientInfo(string userId)
    {
        CheckUserExistsCommand command = new CheckUserExistsCommand(userId);

        bool result = await _commandDispatcher.DispatchAsync<CheckUserExistsCommand, bool>(command);

        return Ok(result);
    }

    [HttpPost("account/login")]
    public async Task<IActionResult> GetClientInfo(LoginRequestDTO loginRequest)
    {
        string result;

        VerifyLoginCommand command = new VerifyLoginCommand(loginRequest);

        bool loginCheck = await _commandDispatcher.DispatchAsync<VerifyLoginCommand, bool>(command);

        if (!loginCheck)
        {
            return Unauthorized();
        }

        GenerateAuthTokenCommand generateTokenCommand = new GenerateAuthTokenCommand(Guid.Parse(loginRequest.clientId));

        result = await _commandDispatcher.DispatchAsync<GenerateAuthTokenCommand, string>(generateTokenCommand);

        return Ok(result);
    }
}
