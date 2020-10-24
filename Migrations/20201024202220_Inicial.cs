using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registro_Detalle.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    SuplidorID = table.Column<int>(nullable: false),
                    ProductosID = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductosID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true),
                    Costo = table.Column<decimal>(nullable: false),
                    Inventario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductosID);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorID);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenID = table.Column<int>(nullable: false),
                    SuplidorID = table.Column<int>(nullable: false),
                    ProductosID = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_OrdenID",
                        column: x => x.OrdenID,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Productos_ProductosID",
                        column: x => x.ProductosID,
                        principalTable: "Productos",
                        principalColumn: "ProductosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Suplidores_SuplidorID",
                        column: x => x.SuplidorID,
                        principalTable: "Suplidores",
                        principalColumn: "SuplidorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductosID", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 1, 22m, "Arroz", 10 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductosID", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 2, 50m, "Azucar", 6 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductosID", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 3, 25m, "Chocolate", 20 });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorID", "Nombres" },
                values: new object[] { 1, "Ramon" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorID", "Nombres" },
                values: new object[] { 2, "Pablo" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorID", "Nombres" },
                values: new object[] { 3, "Cristian" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenID",
                table: "OrdenesDetalle",
                column: "OrdenID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ProductosID",
                table: "OrdenesDetalle",
                column: "ProductosID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_SuplidorID",
                table: "OrdenesDetalle",
                column: "SuplidorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Suplidores");
        }
    }
}
