using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP03SW.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "Produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Produto",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Preco",
                table: "Produto",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuantidadeEstoque",
                table: "Produto",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
