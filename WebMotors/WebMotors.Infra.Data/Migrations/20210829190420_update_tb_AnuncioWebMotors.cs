using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMotors.Infra.Data.Migrations
{
    public partial class update_tb_AnuncioWebMotors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ano",
                table: "tb_AnuncioWebMotors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ano",
                table: "tb_AnuncioWebMotors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
