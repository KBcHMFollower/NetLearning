using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// Условная бд с пользователями
var people = new List<Person>
 {
    new Person("tom@gmail.com", "12345"),
    new Person("bob@gmail.com", "55555")
};

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", (Person loginData) =>
{
    // Находим пользователя 
    Person? person = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
    // Если пользователь не найден, отправляем статусный код 401
    if (person is null) return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
    // Создаем JWT-токен
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    // Формируем ответ
    var response = new
    {
        access_token = encodedJwt,
        username = person.Email
    };

    return Results.Json(response);
});
app.Map("/data", [Authorize] () => new { message = "Hello World!" });

app.Run();

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // Издатель токена
    public const string AUDIENCE = "MyAuthClient"; // Потребитель токена
    const string KEY = "mysupersecret_secretkey!123";   // Ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}

record class Person(string Email, string Password);