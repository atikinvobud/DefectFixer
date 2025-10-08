using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using BackEnd.Models;
using BackEnd.Models.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace BackEnd.Services;

public class JwtService : IJwtService
{
    private readonly string SecretKey;
    private readonly int ExpireHours;
    private readonly string Issuer;
    private readonly string Audience;
    private readonly string CoockieName;
    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        var settings = jwtSettings.Value;
        SecretKey = settings.SecretKey;
        ExpireHours = settings.ExpireHours;
        Issuer = settings.Issuer;
        Audience = settings.Audience;
        CoockieName = settings.CoockieName;
    }
    public string GenerateToken(UserEntity user)
    {
        Claim[] claims = {
             new Claim("userId", user.Id.ToString()),
             new Claim("RoleId", user.RoleId.ToString())
             };

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
        SecurityAlgorithms.HmacSha256);

        var Token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(ExpireHours),
            signingCredentials: signingCredentials
        );

        var TokenValue = new JwtSecurityTokenHandler().WriteToken(Token);
        return TokenValue;
    }

    public string GetCoockieName()
    {
        return CoockieName;
    }

    public int GetExpireHours()
    {
        return ExpireHours;
    }
}