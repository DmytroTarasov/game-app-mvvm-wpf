using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialModel_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarEntityDetailEntity_Cars_CarsId",
                table: "CarEntityDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CarEntityDetailEntity_Details_DetailsId",
                table: "CarEntityDetailEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarEntityDetailEntity",
                table: "CarEntityDetailEntity");

            migrationBuilder.RenameTable(
                name: "CarEntityDetailEntity",
                newName: "CarDetails");

            migrationBuilder.RenameIndex(
                name: "IX_CarEntityDetailEntity_DetailsId",
                table: "CarDetails",
                newName: "IX_CarDetails_DetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDetails",
                table: "CarDetails",
                columns: new[] { "CarsId", "DetailsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_Cars_CarsId",
                table: "CarDetails",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_Details_DetailsId",
                table: "CarDetails",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_Cars_CarsId",
                table: "CarDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_Details_DetailsId",
                table: "CarDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDetails",
                table: "CarDetails");

            migrationBuilder.RenameTable(
                name: "CarDetails",
                newName: "CarEntityDetailEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CarDetails_DetailsId",
                table: "CarEntityDetailEntity",
                newName: "IX_CarEntityDetailEntity_DetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarEntityDetailEntity",
                table: "CarEntityDetailEntity",
                columns: new[] { "CarsId", "DetailsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarEntityDetailEntity_Cars_CarsId",
                table: "CarEntityDetailEntity",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarEntityDetailEntity_Details_DetailsId",
                table: "CarEntityDetailEntity",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
