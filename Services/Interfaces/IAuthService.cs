using jwt_authentication_boilerplate.Data.DTO;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<JwtResultDTO> Authentication(AuthUserDTO authUserDTO);

        public Task<bool> Validation(string emai);
    }
}
