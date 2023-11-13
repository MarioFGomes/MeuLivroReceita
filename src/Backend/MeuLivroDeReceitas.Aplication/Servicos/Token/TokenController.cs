using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MeuLivroDeReceitas.Aplication.Servicos.Token;

public class TokenController
{
    private const string EmailAlias = "eml";
    private readonly double _tempoDeVidaDoTokenEmMinutos;
    private readonly string _ChaveDeSegurana;

    public TokenController(double tempoDeVidaDoTokenEmMinutos, string ChaveDeSegurana)
    {
        _tempoDeVidaDoTokenEmMinutos=tempoDeVidaDoTokenEmMinutos;
        _ChaveDeSegurana=ChaveDeSegurana;
    }

    public string GerarToken(string emailDoUsuario)
    {
        var claims = new List<Claim>
        {
            new Claim(EmailAlias,emailDoUsuario),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_tempoDeVidaDoTokenEmMinutos),
            SigningCredentials = new SigningCredentials(Simetrickey(), SecurityAlgorithms.HmacSha256Signature)
        };
        var SecurityToken= tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(SecurityToken);
    }

    private SymmetricSecurityKey Simetrickey()
    {
        var symmetrickey=Convert.FromBase64String(_ChaveDeSegurana);
        return new SymmetricSecurityKey(symmetrickey);
    }

    public ClaimsPrincipal ValidarToken(string Token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var parametrosValidacao = new TokenValidationParameters
        {
            RequireExpirationTime = true,
            IssuerSigningKey = Simetrickey(),
            ClockSkew = new TimeSpan(0),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
        return tokenHandler.ValidateToken(Token, parametrosValidacao, out _);
    }

    public string RecuperarEmail(string token)
    {
        var claims = ValidarToken(token);

        return claims.FindFirst(EmailAlias).Value;
    }

}

