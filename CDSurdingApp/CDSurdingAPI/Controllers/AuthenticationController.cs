using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthenticationController(IConfiguration config)
    {
        _config = config;
    }

    public record AuthenticationData(string? UserName, string? Password);
    public record UserData(int Id, string FirstName, string LastName, string UserName);

    [HttpPost("token")]
    [AllowAnonymous]
    public ActionResult<string> Authenticate([FromBody] AuthenticationData data)
    {
        var user = ValidateCredentials(data);

        if (user is null)
        {
            return Unauthorized();
        }

        string token = GenerateToken(user);

        return Ok(token);
    }

    private string GenerateToken(UserData user)
    {
        var GEHEIM = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
            _config.GetValue<string>("Authentication:GEHEIM")));
        var ALGO = SecurityAlgorithms.HmacSha256;
        var signingCred = new SigningCredentials(GEHEIM, ALGO);
        List<Claim> clams = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName,user.UserName),
            new(JwtRegisteredClaimNames.GivenName,user.FirstName),
            new(JwtRegisteredClaimNames.FamilyName,user.LastName)
        };
        var ISSUE = _config.GetValue<string>("Authentication:Issuer");
        var AUDIENCE = _config.GetValue<string>("Authentication:Audience");
        var idate = DateTime.UtcNow;
        var exdate = idate.AddMinutes(1);
        var token = new JwtSecurityToken(ISSUE, AUDIENCE, clams, idate, exdate,
            signingCred);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserData? ValidateCredentials(AuthenticationData data)
    {
        /*if (CompareValues(data.UserName, "root") &&
            CompareValues(data.Password, "tor"))
        {
            return new UserData(1, "Olson", "Perrensen", data.UserName!);
        }*/
        if (CompareValues(data.UserName, "test") &&
            CompareValues(data.Password, "test"))
        {
            return new UserData(1, "Test", "User", data.UserName!);
        }

        return null;
    }

    private bool CompareValues(string? actual, string expected)
    {
        if (actual is not null)
        {
            if (actual.Equals(expected))
            {
                return true;
            }
        }
        return false;
    }
}
