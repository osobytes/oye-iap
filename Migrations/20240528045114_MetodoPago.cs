using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyeIap.Server.Migrations
{
    /// <inheritdoc />
    public partial class MetodoPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Tutores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriocidadPago",
                table: "Tutores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Instituciones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriocidadPago",
                table: "Instituciones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "PeriocidadPago",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Instituciones");

            migrationBuilder.DropColumn(
                name: "PeriocidadPago",
                table: "Instituciones");
        }
    }
}
