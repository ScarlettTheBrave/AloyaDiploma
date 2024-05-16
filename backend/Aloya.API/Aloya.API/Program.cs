using Aloya.Core.Auth;
using Aloya.Core.Interfaces;
using Aloya.Core.Services;
using Aloya.Domain.Auth;
using Aloya.Domain.Enums;
using Aloya.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Aloya.API")));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKeys = new List<SecurityKey> { symmetricSecurityKey }
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["mar-cookies"];
                return Task.CompletedTask;
            }
        };

    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireClaim("Admin", "true");
    });
    options.AddPolicy("TeacherPolicy", policy =>
    {
        policy.RequireClaim("Teacher", "true");
    });
    options.AddPolicy("StudentPolicy", policy =>
    {
        policy.RequireClaim("Student", "true");
    });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
app.MapGet("get", () =>
{
    return Results.Ok("ok");
}).RequireAuthorization("AdminPolicy");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCookiePolicy(new CookiePolicyOptions
{
    
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.None,

});
//MinimumSameSitePolicy = SameSiteMode.None,
//HttpOnly = HttpOnlyPolicy.Always,
//Secure = CookieSecurePolicy.None
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAnyOrigin");
app.MapControllers();
app.Run();