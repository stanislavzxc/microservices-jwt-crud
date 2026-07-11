using Microsoft.EntityFrameworkCore;
using aspcorestudy.Data;
using aspcorestudy.Data.Interfaces;
using aspcorestudy.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using aspcorestudy.Interfaces;
using aspcorestudy.Service;

var builder = WebApplication.CreateBuilder(args);

var jwtsettings = builder.Configuration.GetSection("Jwt");
var jwt_key = Encoding.UTF8.GetBytes(jwtsettings["key"]!);
// var jwt_key = Encoding.UTF8.GetBytes(jwtsettings["key"]! ?? "SuperSecretDefaultMigrationKey123456789!!!");


builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
   options.TokenValidationParameters = new TokenValidationParameters
   {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtsettings["Issuer"],
        ValidAudience = jwtsettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(jwt_key)  
   }; 
});

builder.Services.AddControllers();
builder.Services.AddTransient<RandomService>();
builder.Services.AddScoped(typeof(iRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


var app = builder.Build();

app.UseAuthorization();
app.UseAuthentication();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        Console.WriteLine("=> Start migrations...");
        
        await context.Database.MigrateAsync(); 
        
        Console.WriteLine("=> migrations was succesfull!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"=> Error migrations in C#: {ex.Message}");
    }
}

app.MapControllers();

app.MapGet("/", () => "See swagger");

app.Run();
