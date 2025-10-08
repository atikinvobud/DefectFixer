using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class changedproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Reports",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Projects",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Reports",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Reports",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "Address");
        }
    }
}
