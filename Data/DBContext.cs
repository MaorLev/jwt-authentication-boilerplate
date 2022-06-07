using jwt_authentication_boilerplate.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace jwt_authentication_boilerplate.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
               .ToTable("Users")
               .HasDiscriminator();

            modelBuilder.Entity<User>()
            .HasOne<Role>(s => s.Role)
            .WithMany(ad => ad.Users)
            .HasForeignKey(fk => fk.RoleId
            );

            Role role1 = new Role(1, "Admin");

            Role role2 = new Role(2, "Student");
            modelBuilder.Entity<Role>().HasData(role1, role2);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Claims)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);


            Admin adm = new Admin(3, "csdcdc", "admin", "sdsd", "123456", 1);
            modelBuilder.Entity<Admin>().HasData(adm);

            ClaimData claim1adm = new ClaimData(7, "name", adm.FirstName, adm.Id);
            ClaimData claim2adm = new ClaimData(8, "role", role1.Name, adm.Id);
            ClaimData claim3adm = new ClaimData(9, "userId", adm.Id.ToString(), adm.Id);

            Student student = new Student(2, "shlomi@gmail", "Shlomi", "Atar", "1234", "2022", 3);
            modelBuilder.Entity<Student>().HasData(student);
            ClaimData claim1stu = new ClaimData(1, "name", student.FirstName, student.Id);
            ClaimData claim2stu = new ClaimData(2, "role", role2.Name, student.Id);
            ClaimData claim3stu = new ClaimData(3, "userId", student.Id.ToString(), student.Id);

            modelBuilder.Entity<ClaimData>().HasData(claim1adm, claim2adm, claim3adm, claim1stu, claim2stu, claim3stu);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ClaimData> ClaimData { get; set; }
    }
}
