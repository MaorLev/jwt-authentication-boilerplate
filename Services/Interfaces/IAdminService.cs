
using jwt_authentication_boilerplate.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<ResponseDTO> Add(AdminDTO admin);

        public Task<List<AdminDTO>> GetAll();

        public Task<AdminDTO> GetAdmin(int id);

        public Task<ResponseDTO> Update(int id, AdminDTO admin);

        public Task<ResponseDTO> DeleteAdmin(int id);
        public Task<bool> Validation(string emai);
    }
}
