using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MEDICO",
                columns: table => new
                {
                    MEDICOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ESPECIALIDADE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.MEDICOID);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    PACIENTEID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATANASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.PACIENTEID);
                });

            migrationBuilder.CreateTable(
                name: "CONSULTA",
                columns: table => new
                {
                    CONSULTAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATACONSULTA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PACIENTEID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MEDICOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSULTA", x => x.CONSULTAID);
                    table.ForeignKey(
                        name: "FK_CONSULTA_MEDICO_MEDICOID",
                        column: x => x.MEDICOID,
                        principalTable: "MEDICO",
                        principalColumn: "MEDICOID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONSULTA_PACIENTE_PACIENTEID",
                        column: x => x.PACIENTEID,
                        principalTable: "PACIENTE",
                        principalColumn: "PACIENTEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_MEDICOID",
                table: "CONSULTA",
                column: "MEDICOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_PACIENTEID",
                table: "CONSULTA",
                column: "PACIENTEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONSULTA");

            migrationBuilder.DropTable(
                name: "MEDICO");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}
