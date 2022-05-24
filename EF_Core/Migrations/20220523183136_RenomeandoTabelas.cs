using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core.Migrations
{
    public partial class RenomeandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Pedido_PedidoId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Produto_ProdutoId",
                table: "PedidoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Pedidos_PedidoId",
                table: "PedidoItens",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Pedidos_PedidoId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Pedido");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedido",
                newName: "IX_Pedido_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Pedido_PedidoId",
                table: "PedidoItens",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Produto_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
