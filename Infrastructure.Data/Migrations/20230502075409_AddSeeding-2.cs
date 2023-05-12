using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CheckingSeed",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckingSeed",
                table: "CheckingSeed",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Checking_Id",
                table: "CheckingSeed",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckingSeed",
                table: "CheckingSeed");

            migrationBuilder.DropIndex(
                name: "IX_Checking_Id",
                table: "CheckingSeed");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CheckingSeed");
        }
    }
}
