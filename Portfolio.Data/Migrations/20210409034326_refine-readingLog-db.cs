using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Data.Migrations
{
    public partial class refinereadingLogdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_ReadingLogs_ReadingLogId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadingLogs_Books_BookId",
                table: "ReadingLogs");

            migrationBuilder.DropIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "ReadingLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReadingLogId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_ReadingLogs_ReadingLogId",
                table: "Notes",
                column: "ReadingLogId",
                principalTable: "ReadingLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingLogs_Books_BookId",
                table: "ReadingLogs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_ReadingLogs_ReadingLogId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadingLogs_Books_BookId",
                table: "ReadingLogs");

            migrationBuilder.DropIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "ReadingLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReadingLogId",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_ReadingLogs_ReadingLogId",
                table: "Notes",
                column: "ReadingLogId",
                principalTable: "ReadingLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingLogs_Books_BookId",
                table: "ReadingLogs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
