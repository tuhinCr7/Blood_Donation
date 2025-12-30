using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSProject.Migrations
{
    /// <inheritdoc />
    public partial class AddContactFieldsToDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchLogs_BloodGroups_BloodGroupId",
                table: "SearchLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchLogs_Users_UserId",
                table: "SearchLogs");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SearchLogs_BloodGroupId",
                table: "SearchLogs");

            migrationBuilder.DropIndex(
                name: "IX_SearchLogs_UserId",
                table: "SearchLogs");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Donors",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "WhatsApp",
                table: "Donors",
                type: "longtext",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BloodGroups",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Donors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Donors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BloodGroups",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SearchLogs_BloodGroupId",
                table: "SearchLogs",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchLogs_UserId",
                table: "SearchLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SearchLogs_BloodGroups_BloodGroupId",
                table: "SearchLogs",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchLogs_Users_UserId",
                table: "SearchLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
