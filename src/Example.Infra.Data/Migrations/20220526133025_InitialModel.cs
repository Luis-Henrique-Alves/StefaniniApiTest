using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Infra.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
               name: "dbo");

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    District = table.Column<int>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
              name: "Person",
              schema: "dbo",
              columns: table => new
                  {
                 Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
                 Name = table.Column<string>(type: "nvarchar(300)", nullable: false),
                 DocumentNumber = table.Column<int>(type: "nvarchar(11)", nullable: false),
                 Age = table.Column<int>(type: "int", nullable: false),
                 IdCity = table.Column<int>(type: "int", nullable: false)
              },
        constraints: table =>
        {
            table.PrimaryKey("PK_Person", x => x.Id);
     
        });
        migrationBuilder.AddForeignKey(
           name: "FK_Projects_Users_UserId",
           table: "Person",
           column: "IdCity",
           principalTable: "City",
           principalColumn: "Id",
           onDelete:ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "City",
               schema: "dbo");

            migrationBuilder.DropTable(
            name: "Person",
            schema: "dbo");

        }
    }
}
