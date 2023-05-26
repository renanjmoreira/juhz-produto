using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galvanicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilesimosMaoObra = table.Column<int>(type: "int", nullable: false),
                    CotacaoOuro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CotacaoRodio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galvanicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banho = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MilesimosCamada = table.Column<int>(type: "int", nullable: true),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoBanho = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Margem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Galvanicas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
