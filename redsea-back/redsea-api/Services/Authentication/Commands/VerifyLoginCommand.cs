// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

using redsea_api.Services.Commands;

namespace redsea_api.Services.Authentication.Commands;

public class VerifyLoginCommand(LoginRequestDTO loginRequest) : ICommand<bool>
{

    public string Password { get; set; } = loginRequest.password;
    public DateTime TimeStamp { get; set; } = DateTime.Now;

    public Guid CallerId { get; set; } = Guid.Parse(loginRequest.clientId);
}
