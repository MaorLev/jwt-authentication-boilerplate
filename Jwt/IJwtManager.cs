using jwt_authentication_boilerplate.Data.DTO;
using System.Security.Claims;

namespace jwt_authentication_boilerplate.Jwt
{
    public interface IJwtManager
    {
        JwtResultDTO GenerateToken(Claim[] claims);
    }
}
