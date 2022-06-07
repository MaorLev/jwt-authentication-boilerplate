using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Data.Entities
{
    public class Role
    {
        public Role()
        {

        }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
