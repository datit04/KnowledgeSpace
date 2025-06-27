using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeSpace.BackendServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnwerUserId",
                table: "Comments",
                newName: "OwnerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Comments",
                newName: "OwnwerUserId");
        }
    }
}
