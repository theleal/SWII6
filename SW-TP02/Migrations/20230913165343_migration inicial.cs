using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP02___SWII6.Migrations
{
    public partial class migrationinicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentosBL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    Consignee = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    Navio = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosBL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Conteiners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConteiner = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Tipo = table.Column<short>(type: "SMALLINT", nullable: false),
                    Tamanho = table.Column<short>(type: "SMALLINT", nullable: false),
                    ID_DocumentoBL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conteiners_DocumentosBL_ID_DocumentoBL",
                        column: x => x.ID_DocumentoBL,
                        principalTable: "DocumentosBL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conteiners_ID_DocumentoBL",
                table: "Conteiners",
                column: "ID_DocumentoBL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conteiners");

            migrationBuilder.DropTable(
                name: "DocumentosBL");
        }
    }
}
