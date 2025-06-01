using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Store_Warehouse_App.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDeletOnAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Address_AddressId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Supplier");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_SupplierId",
                table: "Address",
                column: "SupplierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Supplier_SupplierId",
                table: "Address",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Supplier_SupplierId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_SupplierId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Address_AddressId",
                table: "Supplier",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
