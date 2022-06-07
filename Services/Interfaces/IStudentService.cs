using jwt_authentication_boilerplate.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<ResponseDTO> Add(StudentDTO student);

        public Task<List<StudentDTO>> GetAll();

        public Task<StudentDTO> GetStudent(int id);

        public Task<ResponseDTO> Update(int id, StudentDTO student);

        public Task<ResponseDTO> DeleteStudent(int id);
        public Task<bool> Validation(string emai);
    }
}
