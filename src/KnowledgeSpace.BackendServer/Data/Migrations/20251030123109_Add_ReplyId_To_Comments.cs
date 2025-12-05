using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeSpace.BackendServer.Data.Migrations
{
	/// <inheritdoc />
	public partial class Add_ReplyId_To_Comments : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "ReplyId",
				table: "Comments",
				type: "int",
				nullable: true);

			// Tạo index để query nhanh
			migrationBuilder.CreateIndex(
				name: "IX_Comments_ReplyId",
				table: "Comments",
				column: "ReplyId");

			// Tạo FK để đảm bảo ReplyId trỏ đến Comment hợp lệ
			migrationBuilder.AddForeignKey(
				name: "FK_Comments_Comments_ReplyId",
				table: "Comments",
				column: "ReplyId",
				principalTable: "Comments",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Comments_Comments_ReplyId",
				table: "Comments");

			migrationBuilder.DropIndex(
				name: "IX_Comments_ReplyId",
				table: "Comments");

			migrationBuilder.DropColumn(
				name: "ReplyId",
				table: "Comments");
		}
	}
}
