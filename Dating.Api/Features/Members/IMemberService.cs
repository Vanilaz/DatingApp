using System;
using Dating.Api.Entities;

namespace Dating.Api.Features.Members;

public interface IMemberService
{
    Task<IReadOnlyList<AppUser>> GetMemberAllAsync();
    Task<AppUser?> GetMemberByIdAsync(string id);
}
