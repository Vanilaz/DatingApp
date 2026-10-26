using System;

namespace Dating.Api.Features.Account;

public sealed record class UserDTO(string Id,string Email,string DisplayName,string Token,string? ImageUrl=null);

