using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NewPainting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Paintings_PaintingId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Orders_OrderId",
                table: "Paintings");

            migrationBuilder.DropIndex(
                name: "IX_Paintings_OrderId",
                table: "Paintings");

            migrationBuilder.RenameColumn(
                name: "PaintingId1",
                table: "Orders",
                newName: "PaintingId2");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaintingId1",
                table: "Orders",
                newName: "IX_Orders_PaintingId2");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaintingId",
                table: "Orders",
                column: "PaintingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Paintings_PaintingId",
                table: "Orders",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Paintings_PaintingId2",
                table: "Orders",
                column: "PaintingId2",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Paintings_PaintingId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Paintings_PaintingId2",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaintingId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaintingId2",
                table: "Orders",
                newName: "PaintingId1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaintingId2",
                table: "Orders",
                newName: "IX_Orders_PaintingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_OrderId",
                table: "Paintings",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Paintings_PaintingId1",
                table: "Orders",
                column: "PaintingId1",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Orders_OrderId",
                table: "Paintings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
