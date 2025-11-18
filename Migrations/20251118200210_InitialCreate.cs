using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoBoxApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FornecedorProduto");

            migrationBuilder.DropTable(
                name: "ProdutoSaida");

            migrationBuilder.DropColumn(
                name: "SaidaId",
                table: "Produtos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataSaida",
                table: "Saidas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_ProdutoId",
                table: "Saidas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_ProdutoId1",
                table: "Saidas",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId1",
                table: "Produtos",
                column: "FornecedorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId1",
                table: "Produtos",
                column: "FornecedorId1",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Produtos_ProdutoId",
                table: "Saidas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Produtos_ProdutoId1",
                table: "Saidas",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId1",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Produtos_ProdutoId",
                table: "Saidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Produtos_ProdutoId1",
                table: "Saidas");

            migrationBuilder.DropIndex(
                name: "IX_Saidas_ProdutoId",
                table: "Saidas");

            migrationBuilder.DropIndex(
                name: "IX_Saidas_ProdutoId1",
                table: "Saidas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorId1",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "Saidas");

            migrationBuilder.DropColumn(
                name: "FornecedorId1",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "DataSaida",
                table: "Saidas",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "SaidaId",
                table: "Produtos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FornecedorProduto",
                columns: table => new
                {
                    FornecedoresId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorProduto", x => new { x.FornecedoresId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_FornecedorProduto_Fornecedores_FornecedoresId",
                        column: x => x.FornecedoresId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FornecedorProduto_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoSaida",
                columns: table => new
                {
                    ProdutosId = table.Column<int>(type: "INTEGER", nullable: false),
                    SaidasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoSaida", x => new { x.ProdutosId, x.SaidasId });
                    table.ForeignKey(
                        name: "FK_ProdutoSaida_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoSaida_Saidas_SaidasId",
                        column: x => x.SaidasId,
                        principalTable: "Saidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorProduto_ProdutosId",
                table: "FornecedorProduto",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoSaida_SaidasId",
                table: "ProdutoSaida",
                column: "SaidasId");
        }
    }
}
