using System;
using Dating.Api.Entities;
using Dating.Api.Features.Account;

namespace Dating.Api.Features.Members.Account;

public interface IAccountService
{
    Task<UserDTO> Register(RegisterDTOs request);
    Task<UserDTO> Login (LoginDTOs request);
}
