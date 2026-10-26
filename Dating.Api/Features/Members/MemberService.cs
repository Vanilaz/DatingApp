using System;
using Dating.Api.Data;
using Dating.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dating.Api.Features.Members;

public class MemberService(AppDbContext context) : IMemberService
{
    public async Task<IReadOnlyList<AppUser>> GetMemberAllAsync() => await context.AppUsers.AsNoTracking().ToListAsync();
    public async Task<AppUser?> GetMemberByIdAsync(string id) 
        => await context.AppUsers.FindAsync(id);
}
