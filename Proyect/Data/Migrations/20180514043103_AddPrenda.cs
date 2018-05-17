using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Proyect.Data.Migrations
{
    public partial class AddPrenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenda",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Comprada = table.Column<DateTimeOffset>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false),
                    Tamano = table.Column<string>(nullable: true),
                    id_del_producto = table.Column<int>(nullable: false),
                    imagen = table.Column<string>(nullable: true),
                    precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenda", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenda");
        }
    }
}
