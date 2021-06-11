using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaTroco.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransacaoCedula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    TransacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoCedula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacaoCedula_Transacao_TransacaoId",
                        column: x => x.TransacaoId,
                        principalTable: "Transacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoCedula_TransacaoId",
                table: "TransacaoCedula",
                column: "TransacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransacaoCedula");

            migrationBuilder.DropTable(
                name: "Transacao");
        }
    }
}
