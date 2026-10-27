using Dating.Api.Data;
using Dating.Api.Entities;
using Dating.Api.Extensions;
using Dating.Api.Features.Account;
using Dating.Api.Infrastructure.Data.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Dating.Api.Features.Members.Account;

public class AccountService(AppDbContext context, ITokenService tokenService) : IAccountService
{
    public async Task<UserDTO> Login(LoginDTOs request)
    {
        // 1. แปลงอีเมลที่ส่งเข้ามาเป็นพิมพ์เล็ก
        var email = request.email.ToLower();

        // 2. ค้นหา User จากฐานข้อมูล
        var user = await context.AppUsers.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Email == email);

        // 3. ป้องกัน NullReferenceException ถ้าไม่เจอผู้ใช้
        if (user is null) throw new Exception("ไม่พบรหัสใช้งาน");

        // 4. ตรวจสอบรหัสผ่านว่าตรงกับ Hash หรือไม่
        var isValid = BCrypt.Net.BCrypt.Verify(request.password, user.PasswordHash);

        if (!isValid) throw new Exception("รหัสผ่านไม่ถูกต้อง");


        return user.ToDto(tokenService);
    }

    public async Task<UserDTO> Register(RegisterDTOs request)
    {
        var email = request.Email.ToLower();
        var existing = await context.AppUsers.AnyAsync(x => x.Email.ToLower() == email.ToLower());

        if (existing) throw new InvalidOperationException("อีเมลนี้ถูกใช้งานแล้ว");
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.password);
        var user = new AppUser
        {
            DisplayName = request.DisplayName,
            Email = email,
            PasswordHash = passwordHash
        };

        await context.AppUsers.AddAsync(user);
        await context.SaveChangesAsync();

        return user.ToDto(tokenService);
    }
}
