using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMotors.Infra.Data.Migrations
{
    public partial class add_tb_AnuncioWebMotors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_AnuncioWebMotors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AnuncioWebMotors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AnuncioWebMotors");
        }
    }
}
