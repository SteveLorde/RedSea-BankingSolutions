using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redsea_api.Services.Banking.Commands;
using redsea_api.Services.Commands;
using redsea_database.DTOs.Banking;

namespace redsea_api.Controllers;

[Route("banking/general")]
[Authorize]
public class GeneralController(CommandDispatcher commandDispatcher) : BaseController
{
    private readonly CommandDispatcher _commandDispatcher = commandDispatcher;

    [HttpGet("clientinfo/{clientid}")]
    public async Task<IActionResult> GetClientInfo(string clientid)
    {
        GetClientInfoCommand command = new GetClientInfoCommand(Guid.Parse(clientid));

        ClientInfo result = await _commandDispatcher.DispatchAsync<GetClientInfoCommand, ClientInfo>(command);

        return Ok(result);
    }

    [HttpGet("clientgeneralfinances/{clientid}")]
    public async Task<IActionResult> GetClientGeneralFinances(string clientid)
    {
        GetClientGeneralFinancesCommand command = new GetClientGeneralFinancesCommand(Guid.Parse(clientid));

        ClientGeneralFinances result = await _commandDispatcher.DispatchAsync<GetClientGeneralFinancesCommand, ClientGeneralFinances>(command);

        return Ok(result);
    }
}
