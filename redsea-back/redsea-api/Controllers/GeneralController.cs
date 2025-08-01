using Microsoft.AspNetCore.Mvc;
using redsea_api.Services.Banking.Commands;
using redsea_api.Services.Commands;
using redsea_database.DTOs.Banking;

namespace redsea_api.Controllers;

[Route("banking/general")]
public class GeneralController(CommandDispatcher commandDispatcher) : BaseController
{
    private readonly CommandDispatcher _commandDispatcher = commandDispatcher;

    [HttpGet("clientinfo/{clientid}")]
    public async Task<IActionResult> GetClientInfo(string clientid)
    {
        var command = new GetClientInfoGetCommand(Guid.Parse(clientid));

        var result = await _commandDispatcher.DispatchAsync<GetClientInfoGetCommand, ClientInfo>(command);
        
        return Ok(result);
    }
    
    [HttpGet("clientgeneralfinances/{clientid}")]
    public async Task<IActionResult> GetClientGeneralFinances(string clientid)
    {
        var command = new GetClientGeneralFinancesCommand(Guid.Parse(clientid));
        
        var result = await _commandDispatcher.DispatchAsync<GetClientGeneralFinancesCommand, ClientGeneralFinances>(command);
        
        return Ok(result);
    }
}