using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S4_Progra_Web.Server.Migrations
{
    /// <inheritdoc />
    public partial class withdualkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidosDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PedidosFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PedidosEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidosId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProveedorCorreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProveedorTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Cubes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cubes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cubes_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CubePedidos",
                columns: table => new
                {
                    CubeId = table.Column<int>(type: "int", nullable: false),
                    PedidosId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CubePedidos", x => new { x.CubeId, x.PedidosId });
                    table.ForeignKey(
                        name: "FK_CubePedidos_Cubes_CubeId",
                        column: x => x.CubeId,
                        principalTable: "Cubes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CubePedidos_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CubePedidos_PedidosId",
                table: "CubePedidos",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cubes_ProveedorId",
                table: "Cubes",
                column: "ProveedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CubePedidos");

            migrationBuilder.DropTable(
                name: "Cubes");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
