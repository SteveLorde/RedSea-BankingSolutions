// Licensed to SteveLorde/Mostafa Maher under MIT license.

using Microsoft.AspNetCore.Mvc;

namespace redsea_investing_api.Controllers;

[Microsoft.AspNetCore.Components.Route("invest")]
public class InvestController : BaseController
{
    public async Task<IActionResult> InvestIntoStock(InvestRequest investRequest)
    {
        var result;

        return Ok(result);
    }
}
