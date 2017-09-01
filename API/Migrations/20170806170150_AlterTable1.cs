using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AlterTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos");

            migrationBuilder.DropIndex(
                name: "IX_Pratos_RestauranteId",
                table: "Pratos");

            migrationBuilder.DropColumn(
                name: "RestauranteId",
                table: "Pratos");

            migrationBuilder.AddColumn<long>(
                name: "Restaurante_Id",
                table: "Pratos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_Restaurante_Id",
                table: "Pratos",
                column: "Restaurante_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_Restaurante_Id",
                table: "Pratos",
                column: "Restaurante_Id",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_Restaurante_Id",
                table: "Pratos");

            migrationBuilder.DropIndex(
                name: "IX_Pratos_Restaurante_Id",
                table: "Pratos");

            migrationBuilder.DropColumn(
                name: "Restaurante_Id",
                table: "Pratos");

            migrationBuilder.AddColumn<long>(
                name: "RestauranteId",
                table: "Pratos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_RestauranteId",
                table: "Pratos",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
