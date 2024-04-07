using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArtStudio.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ArtStudio.Core.Infrastructure;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private JwtOptions Options { get; } = options.Value;
    
    public string Generate(UserEntity user)
    {
        Claim[] claims = [new("userId", user.Id.ToString())];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(Options.ExpiresHours));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}