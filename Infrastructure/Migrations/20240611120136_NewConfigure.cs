using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NewConfigure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Paintings_PaintingId2",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaintingId2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaintingId2",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaintingId2",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaintingId2",
                table: "Orders",
                column: "PaintingId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Paintings_PaintingId2",
                table: "Orders",
                column: "PaintingId2",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
