using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MembershipsNetCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFKPersonTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teacher_PersonId",
                table: "Teacher");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_PersonId",
                table: "Teacher",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teacher_PersonId",
                table: "Teacher");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_PersonId",
                table: "Teacher",
                column: "PersonId");
        }
    }
}
