namespace Filmes.Infra.Security.Settings;

public class JwtSettings
{
    public string Secretkey { get; set; }
    public int ExpirationHours { get; set; }
}