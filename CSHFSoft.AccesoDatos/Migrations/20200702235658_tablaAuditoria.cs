using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHFSoft.AccesoDatos.Migrations
{
    public partial class tablaAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    idAuditoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false),
                    accion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.idAuditoria);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria");
        }
    }
}
