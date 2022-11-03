using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketCompId",
                table: "History",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_BasketCompId",
                table: "History",
                column: "BasketCompId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_BasketComp_BasketCompId",
                table: "History",
                column: "BasketCompId",
                principalTable: "BasketComp",
                principalColumn: "BasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_BasketComp_BasketCompId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_BasketCompId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "BasketCompId",
                table: "History");
        }
    }
}
