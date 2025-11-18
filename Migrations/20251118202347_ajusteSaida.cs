using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoBoxApi.Migrations
{
    /// <inheritdoc />
    public partial class ajusteSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId1",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Produtos_ProdutoId1",
                table: "Saidas");

            migrationBuilder.DropIndex(
                name: "IX_Saidas_ProdutoId1",
                table: "Saidas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorId1",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "Saidas");

            migrationBuilder.DropColumn(
                name: "FornecedorId1",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Fornecedores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "Saidas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId1",
                table: "Produtos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Fornecedores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_ProdutoId1",
                table: "Saidas",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId1",
                table: "Produtos",
                column: "FornecedorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId1",
                table: "Produtos",
                column: "FornecedorId1",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Produtos_ProdutoId1",
                table: "Saidas",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
