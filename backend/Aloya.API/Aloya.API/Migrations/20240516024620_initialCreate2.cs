using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aloya.API.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AreaAnswers");

            migrationBuilder.AddColumn<byte[]>(
                name: "photo",
                table: "AreaTasks",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<double>(
                name: "Radius",
                table: "AreaAnswers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "X",
                table: "AreaAnswers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Y",
                table: "AreaAnswers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo",
                table: "AreaTasks");

            migrationBuilder.DropColumn(
                name: "Radius",
                table: "AreaAnswers");

            migrationBuilder.DropColumn(
                name: "X",
                table: "AreaAnswers");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "AreaAnswers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "AreaAnswers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
