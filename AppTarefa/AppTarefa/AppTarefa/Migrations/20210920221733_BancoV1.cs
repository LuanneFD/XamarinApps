using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTarefa.Migrations
{
    public partial class BancoV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarefasApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: true),
                    HoraInicial = table.Column<TimeSpan>(nullable: false),
                    HoraFinal = table.Column<TimeSpan>(nullable: false),
                    Nota = table.Column<string>(nullable: true),
                    Finalizada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasApp", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarefasApp");
        }
    }
}
