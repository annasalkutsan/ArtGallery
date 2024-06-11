using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NewM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Paintings_PaintingId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Paintings_PaintingId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Images_ImageId",
                table: "Paintings");

            migrationBuilder.DropIndex(
                name: "IX_Paintings_ImageId",
                table: "Paintings");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaintingId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Images_PaintingId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Authors_UserId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Paintings");

            migrationBuilder.DropColumn(
                name: "PaintingId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Paintings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PaintingId1",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FullName_FirstName",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName_LastName",
                table: "Authors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName_MiddleName",
                table: "Authors",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaintingId1",
                table: "Orders",
                column: "PaintingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Paintings_PaintingId1",
                table: "Orders",
                column: "PaintingId1",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Paintings_PaintingId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaintingId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Paintings");

            migrationBuilder.DropColumn(
                name: "PaintingId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullName_FirstName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "FullName_LastName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "FullName_MiddleName",
                table: "Authors");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Paintings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaintingId",
                table: "Images",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Authors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ImageId",
                table: "Paintings",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaintingId",
                table: "Orders",
                column: "PaintingId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PaintingId",
                table: "Images",
                column: "PaintingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Paintings_PaintingId",
                table: "Images",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Paintings_PaintingId",
                table: "Orders",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Images_ImageId",
                table: "Paintings",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
