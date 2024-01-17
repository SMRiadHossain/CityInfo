using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Users_UserId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsOfInterest_Users_UserId",
                table: "PointsOfInterest");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PointsOfInterest",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_PointsOfInterest_UserId",
                table: "PointsOfInterest",
                newName: "IX_PointsOfInterest_userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cities",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_UserId",
                table: "Cities",
                newName: "IX_Cities_userId");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Users",
                type: "varchar(255)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "PointsOfInterest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PointsOfInterest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cities",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Users_userId",
                table: "Cities",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointsOfInterest_Users_userId",
                table: "PointsOfInterest",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Users_userId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsOfInterest_Users_userId",
                table: "PointsOfInterest");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "PointsOfInterest",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PointsOfInterest_userId",
                table: "PointsOfInterest",
                newName: "IX_PointsOfInterest_UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Cities",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_userId",
                table: "Cities",
                newName: "IX_Cities_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PointsOfInterest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PointsOfInterest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cities",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Users_UserId",
                table: "Cities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsOfInterest_Users_UserId",
                table: "PointsOfInterest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
