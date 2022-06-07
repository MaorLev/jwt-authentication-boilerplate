namespace jwt_authentication_boilerplate.Data.Entities
{
    public class Admin : User
    {
        public Admin()
        {
        }
        public Admin(int Id, string Mail, string FirstName, string LastName, string Password, int RoleId)
            : base(Id, Mail, FirstName, LastName, Password, RoleId)
        {

        }
    }
}
