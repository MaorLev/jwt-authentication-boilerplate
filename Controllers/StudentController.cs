using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jwt_authentication_boilerplate.Data.DTO;
using jwt_authentication_boilerplate.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static jwt_authentication_boilerplate.Extensions.ConstantsRoles;

namespace jwt_authentication_boilerplate.Controllers
{
    [Authorize(Roles = RolesName.Admin + "," + RolesName.Student)]
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service = service;
        }


        //In case, that request only from admin
        [Authorize(Roles = RolesName.Admin)]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {

                List<StudentDTO> result = await service.GetAll();
                if(result != null) return Ok(result);

                return NotFound("No Results");
            }
            catch
            {
                return BadRequest("Error in server");
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                StudentDTO resultStudent = await service.GetStudent(id);
                    if(resultStudent != null) return Ok(resultStudent);

                    return NotFound("No Result");
                }
            catch
            {
                    return BadRequest("Error in server");
            }

         }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostStudent(StudentDTO student)
        {
            try
            {
                if (student != null || student.Password != null || student.Mail != null)
                {
                    if (!await service.Validation(student.Mail))
                    {
                        ResponseDTO respone = await service.Add(student);
                        if (respone.Status == Data.DTO.StatusCode.Success)
                        {
                            return Created("", null);
                        }
                        return BadRequest(respone);
                    }
                    return BadRequest(new ResponseDTO { StatusText = "mail already exist" });
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return BadRequest("Erorr Server");
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> PutStudent(int id, StudentDTO student)
        {
            ResponseDTO response = new ResponseDTO();
            if (id != student.Id)
            {
                response.StatusText = "id does not match";
                return BadRequest(response);
            }

            try
            {
                response = await service.Update(id, student);
                if (response.Status == Data.DTO.StatusCode.Success)
                {
                    return Ok(response);
                }
            }
            catch
            {
                response.Status = Data.DTO.StatusCode.Error;
                response.StatusText = "ERROR";
            return BadRequest(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                ResponseDTO response = await service.DeleteStudent(id);
                if (response.Status == Data.DTO.StatusCode.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception)
            {

                return BadRequest("Erorr Server");
            }

        }
    }
}
