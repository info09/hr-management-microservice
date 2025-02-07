using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contacts",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ContactType",
                table: "Contacts",
                newName: "ContactValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Contacts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ContactValue",
                table: "Contacts",
                newName: "ContactType");
        }
    }
}
