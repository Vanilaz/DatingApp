using System.Text;
using Dating.Api.Data;
using Dating.Api.Features.Members;
using Dating.Api.Features.Members.Account;
using Dating.Api.Infrastructure.Data.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddCors();

//Register Dependency (DI)
builder.Services.AddScoped<IMemberService,MemberService>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<ITokenService,TokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var tokenKey = builder.Configuration["TokenKey"] ?? throw new Exception("Token key not found - Program.cs");

    options.TokenValidationParameters=new TokenValidationParameters()
    {
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
        ValidateIssuer=false,
        ValidateAudience=false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200","https://localhost:4200");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
