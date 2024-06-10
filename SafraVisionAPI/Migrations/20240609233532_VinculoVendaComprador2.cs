using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafraVisionAPI.Migrations
{
    public partial class VinculoVendaComprador2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Comprador_CompradorId",
                table: "Venda");

            migrationBuilder.RenameColumn(
                name: "CompradorId",
                table: "Venda",
                newName: "idComprador");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_CompradorId",
                table: "Venda",
                newName: "IX_Venda_idComprador");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Comprador_idComprador",
                table: "Venda",
                column: "idComprador",
                principalTable: "Comprador",
                principalColumn: "idComprador",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Comprador_idComprador",
                table: "Venda");

            migrationBuilder.RenameColumn(
                name: "idComprador",
                table: "Venda",
                newName: "CompradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_idComprador",
                table: "Venda",
                newName: "IX_Venda_CompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Comprador_CompradorId",
                table: "Venda",
                column: "CompradorId",
                principalTable: "Comprador",
                principalColumn: "idComprador",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
