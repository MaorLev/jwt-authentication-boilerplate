
using System.ComponentModel.DataAnnotations;


namespace jwt_authentication_boilerplate.Data.Entities
{
    public class Student : User
    {

        public Student()
        {

        }


        public Student(int id, string mail, string firstName,
            string lastName, string password,
            string studyStartYear, int RoleId) :
        base(id, mail, firstName, lastName, password, RoleId)
        {
            StudyStartYear = studyStartYear;
        }
        [Required]
        [StringLength(30)]
        public string StudyStartYear { get; set; }
    }
}
