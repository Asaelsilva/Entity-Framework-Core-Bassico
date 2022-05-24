using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Telefone = table.Column<string>(type: "CHAR(11)", nullable: false),
                    CEP = table.Column<string>(type: "CHAR(8)", nullable: false),
                    Estado = table.Column<string>(type: "CHAR(2)", nullable: false),
                    Cidade = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodigoBarras = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TipoProduto = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    IniciadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    FinalizadoEm = table.Column<DateTime>(nullable: false),
                    TipoFrete = table.Column<int>(nullable: false),
                    StatusPedido = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false, defaultValue: 1),
                    Valor = table.Column<decimal>(nullable: false),
                    Desconto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cliente_telefone",
                table: "Cliente",
                column: "Telefone");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_PedidoId",
                table: "PedidoItens",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItens");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
