using Microsoft.EntityFrameworkCore.Migrations;

namespace jwt_authentication_boilerplate.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyStartYear = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimData_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Student" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "Mail", "Password", "RoleId", "StudyStartYear" },
                values: new object[] { 2, "Student", "Shlomi", "Atar", "shlomi@gmail", "1234", 3, "2022" });

            migrationBuilder.InsertData(
                table: "ClaimData",
                columns: new[] { "Id", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, "name", 2, "Shlomi" },
                    { 2, "role", 2, "Student" },
                    { 3, "userId", 2, "2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "Mail", "Password", "RoleId" },
                values: new object[] { 3, "Admin", "admin", "sdsd", "csdcdc", "123456", 1 });

            migrationBuilder.InsertData(
                table: "ClaimData",
                columns: new[] { "Id", "Type", "UserId", "Value" },
                values: new object[] { 7, "name", 3, "admin" });

            migrationBuilder.InsertData(
                table: "ClaimData",
                columns: new[] { "Id", "Type", "UserId", "Value" },
                values: new object[] { 8, "role", 3, "Admin" });

            migrationBuilder.InsertData(
                table: "ClaimData",
                columns: new[] { "Id", "Type", "UserId", "Value" },
                values: new object[] { 9, "userId", 3, "3" });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimData_UserId",
                table: "ClaimData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimData");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
