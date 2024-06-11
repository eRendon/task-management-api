using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModifyStateColumnTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stat",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Tasks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Tasks");

            migrationBuilder.AddColumn<short>(
                name: "Stat",
                table: "Tasks",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
