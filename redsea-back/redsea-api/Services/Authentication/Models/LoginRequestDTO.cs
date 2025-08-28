// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

namespace redsea_api.Services.Authentication;

public record LoginRequestDTO(
    string clientId,
    string password);
