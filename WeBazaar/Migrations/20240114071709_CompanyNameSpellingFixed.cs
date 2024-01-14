using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeBazaar.Migrations
{
    /// <inheritdoc />
    public partial class CompanyNameSpellingFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Comapnies_CompanyId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comapnies",
                table: "Comapnies");

            migrationBuilder.RenameTable(
                name: "Comapnies",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Companies_CompanyId",
                table: "Items",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Companies_CompanyId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Comapnies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comapnies",
                table: "Comapnies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Comapnies_CompanyId",
                table: "Items",
                column: "CompanyId",
                principalTable: "Comapnies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
