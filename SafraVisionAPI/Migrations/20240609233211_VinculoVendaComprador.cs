using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafraVisionAPI.Migrations
{
    public partial class VinculoVendaComprador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idComprador",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_CompradorId",
                table: "Venda",
                column: "CompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Comprador_CompradorId",
                table: "Venda",
                column: "CompradorId",
                principalTable: "Comprador",
                principalColumn: "idComprador",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Comprador_CompradorId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_CompradorId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "CompradorId",
                table: "Venda");
        }
    }
}
