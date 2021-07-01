using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ChangeInitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accumulators_Details_DetailId",
                table: "Accumulators");

            migrationBuilder.DropForeignKey(
                name: "FK_Disks_Details_DetailId",
                table: "Disks");

            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Details_DetailId",
                table: "Engines");

            migrationBuilder.RenameColumn(
                name: "DetailId",
                table: "Engines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DetailId",
                table: "Disks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DetailId",
                table: "Accumulators",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accumulators_Details_Id",
                table: "Accumulators",
                column: "Id",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disks_Details_Id",
                table: "Disks",
                column: "Id",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Details_Id",
                table: "Engines",
                column: "Id",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accumulators_Details_Id",
                table: "Accumulators");

            migrationBuilder.DropForeignKey(
                name: "FK_Disks_Details_Id",
                table: "Disks");

            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Details_Id",
                table: "Engines");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Engines",
                newName: "DetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Disks",
                newName: "DetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accumulators",
                newName: "DetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accumulators_Details_DetailId",
                table: "Accumulators",
                column: "DetailId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disks_Details_DetailId",
                table: "Disks",
                column: "DetailId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Details_DetailId",
                table: "Engines",
                column: "DetailId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
