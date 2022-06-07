using jwt_authentication_boilerplate.Data;
using jwt_authentication_boilerplate.Data.DTO;
using jwt_authentication_boilerplate.Data.Entities;
using jwt_authentication_boilerplate.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static jwt_authentication_boilerplate.Extensions.ConstantsRoles;

namespace jwt_authentication_boilerplate.Services
{
    public class StudentService : IStudentService
    {
        private readonly DBContext m_db;
        private readonly IClaimService claim;
        public StudentService(DBContext db, IClaimService claim)
        {
            m_db = db;
            this.claim = claim;
        }
        public async Task<ResponseDTO> Add(StudentDTO student)
        {
            Role role = await m_db.Role.Where(x => x.Id == RolesId.Student).FirstOrDefaultAsync();

            Student StudentFromDB = new Student(0, student.Mail, student.FirstName
               , student.LastName, student.Password, student.StudyStartYear, RolesId.Student);

                await m_db.Students.AddAsync(StudentFromDB);

                int c = await m_db.SaveChangesAsync();

            ResponseDTO response = new ResponseDTO();
            if (c > 0)
            {
                bool Affected = await claim.PersistClaimsForUser(StudentFromDB);
                if (Affected)
                {
                    response.Status = StatusCode.Success;
                    return response;
                }
                response.Status = StatusCode.Warning;
                response.StatusText = "student adedd BUT presist Not Apply";
                return response;
            }
            response.Status = StatusCode.Faild;
            return response;

        }

        public async Task<List<StudentDTO>> GetAll()
        {


            try
            {
                var students = await m_db.Students.Select(s => new StudentDTO()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Id = s.Id,
                    Mail = s.Mail,
                    Password = s.Password,
                    StudyStartYear = s.StudyStartYear,

                }).ToListAsync();
                return students;
            }
            catch
            {

                throw;
            }


        }

        public async Task<StudentDTO> GetStudent(int id)
        {

            try
            {
                StudentDTO student = await m_db.Students.Select(s => new StudentDTO()
                {
                    FirstName = s.FirstName,
                    Id = s.Id,
                    LastName = s.LastName,
                    Mail = s.Mail,
                    Password = s.Password,
                    StudyStartYear = s.StudyStartYear

                }).FirstOrDefaultAsync(i => i.Id == id);
                return student;
            }
            catch 
            {

                throw;
            }

        }

        public async Task<ResponseDTO> Update(int id, StudentDTO student)
        {
            try
            {
                StudentDTO originalStudent = await GetStudent(id);
                Student StudentFromDB = new Student();
                if (StudentFromDB == null)
                {
                    return new ResponseDTO()
                    {
                        Status = StatusCode.Error,
                        StatusText = $"Item with id {id} not found in DB"
                    };
                }

                StudentFromDB.Mail = originalStudent.Mail;
                StudentFromDB.FirstName = student.FirstName ?? originalStudent.FirstName;
                StudentFromDB.LastName = student.LastName ?? originalStudent.LastName;
                StudentFromDB.StudyStartYear = student.StudyStartYear ?? originalStudent.StudyStartYear;
                StudentFromDB.Id = Convert.ToInt32(student.Id.ToString() ?? originalStudent.Id.ToString());
                StudentFromDB.RoleId = RolesId.Student;


                m_db.Entry(StudentFromDB).State = EntityState.Modified;

                int c = await m_db.SaveChangesAsync();
                ResponseDTO response = new ResponseDTO();
                if (c > 0)
                {
                    response.StatusText = c + " Students affected";
                    response.Status = StatusCode.Success;
                }
                else
                {
                    response.Status = StatusCode.Faild;
                    response.StatusText = "faild no Student affacted";
                }
                return response;
            }
            catch 
            {

                return new ResponseDTO()
                {
                    Status = StatusCode.Error,
                    StatusText = $"Erorrs in service"
                };
            }
            
        }

        public async Task<ResponseDTO> DeleteStudent(int id)
        {
            try
            {
                StudentDTO student = await GetStudent(id);

                if (student == null)
                {
                    return new ResponseDTO() { StatusText = "this object not exists", Status = StatusCode.Faild };
                }

                m_db.Students.Remove(new Student { Id = student.Id });
                int c = await m_db.SaveChangesAsync();
                ResponseDTO response = new ResponseDTO();
                if (c > 0)
                {
                    response.StatusText = "Successfully object deleted";
                    response.Status = StatusCode.Success;
                }
                else
                {
                    response.Status = StatusCode.Error;
                }
                return response;
            }
            catch 
            {

                return new ResponseDTO()
                {
                    Status = StatusCode.Error,
                    StatusText = $"Erorrs in service"
                };
            }

        }
        public async Task<bool> Validation(string emai)
        {
            if (await m_db.Students.Where(i => i.Mail == emai).FirstOrDefaultAsync() != null)
            {
                return true;
            }
            return false;
        }
    }
}
