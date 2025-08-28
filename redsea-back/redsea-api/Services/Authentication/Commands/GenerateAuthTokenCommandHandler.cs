// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

using redsea_api.Services.Commands;
using redsea_api.Services.JWT;

namespace redsea_api.Services.Authentication.Commands;

public class GenerateAuthTokenCommandHandler(IJWT jwtService) : ICommandHandler<GenerateAuthTokenCommand, string>
{
    private readonly IJWT _jwtService = jwtService;

    public async Task<string> HandleAsync(GenerateAuthTokenCommand command)
    {
        string token = _jwtService.GenerateToken(command.CallerId);

        return token;
    }
}
