using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Store_Warehouse_App.Migrations
{
    /// <inheritdoc />
    public partial class InstrumentSupplier_Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_Supplier_SupplierId",
                table: "Instrument");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_Supplier_SupplierId",
                table: "Instrument",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_Supplier_SupplierId",
                table: "Instrument");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_Supplier_SupplierId",
                table: "Instrument",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId");
        }
    }
}
