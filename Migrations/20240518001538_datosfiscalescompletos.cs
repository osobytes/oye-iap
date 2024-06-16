using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyeIap.Server.Migrations
{
    /// <inheritdoc />
    public partial class datosfiscalescompletos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonaMoral",
                table: "Tutores",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "PersonaFisica",
                table: "Tutores",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "CorreoEmpresa",
                table: "Tutores",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegimenFiscal",
                table: "Tutores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "comentarios",
                table: "Tutores",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorreoEmpresa",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "RegimenFiscal",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "comentarios",
                table: "Tutores");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaMoral",
                table: "Tutores",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaFisica",
                table: "Tutores",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
