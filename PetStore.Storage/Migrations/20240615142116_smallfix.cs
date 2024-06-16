using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetStore.Storage.Migrations
{
    /// <inheritdoc />
    public partial class smallfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecieId1",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpecieId1",
                table: "Animals",
                column: "SpecieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Species_SpecieId1",
                table: "Animals",
                column: "SpecieId1",
                principalTable: "Species",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Species_SpecieId1",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_SpecieId1",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "SpecieId1",
                table: "Animals");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
