using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollXpert.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProfileImagePathToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "Employees",
                newName: "ProfileImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImagePath",
                table: "Employees",
                newName: "ProfileImage");
        }
    }
}
