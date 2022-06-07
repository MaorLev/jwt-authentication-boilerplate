using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Data.Entities
{
    public class User
    {
        public User(){}
        public User(int id, string mail, string firstName, string lastName, string password, int RoleId
)
        {
            this.Id = id;
            this.Mail = mail;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.RoleId = RoleId;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(150)]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }


        public ICollection<ClaimData> Claims { get; set; }


        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
