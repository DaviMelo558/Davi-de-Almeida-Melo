using Microsoft.EntityFrameworkCore.Migrations;

namespace RecodeTrip.Migrations
{
    public partial class Viagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companhias",
                columns: table => new
                {
                    Id_companhia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota_avaliacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companhias", x => x.Id_companhia);
                });

            migrationBuilder.CreateTable(
                name: "Viagens",
                columns: table => new
                {
                    Id_viagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data_ida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanhiaId_companhia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagens", x => x.Id_viagem);
                    table.ForeignKey(
                        name: "FK_Viagens_Companhias_CompanhiaId_companhia",
                        column: x => x.CompanhiaId_companhia,
                        principalTable: "Companhias",
                        principalColumn: "Id_companhia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    ViagemId_viagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Viagens_ViagemId_viagem",
                        column: x => x.ViagemId_viagem,
                        principalTable: "Viagens",
                        principalColumn: "Id_viagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ViagemId_viagem",
                table: "Clientes",
                column: "ViagemId_viagem");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_CompanhiaId_companhia",
                table: "Viagens",
                column: "CompanhiaId_companhia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Viagens");

            migrationBuilder.DropTable(
                name: "Companhias");
        }
    }
}
