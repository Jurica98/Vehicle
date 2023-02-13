using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeEntitysId",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_VehicleMakeEntitysId",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "VehicleMakeEntitysId",
                table: "VehicleModels");

            migrationBuilder.RenameColumn(
                name: "VehicleMakeId",
                table: "VehicleModels",
                newName: "VehicleMakeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleMakeEntityId",
                table: "VehicleModels",
                column: "VehicleMakeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeEntityId",
                table: "VehicleModels",
                column: "VehicleMakeEntityId",
                principalTable: "VehicleMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeEntityId",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_VehicleMakeEntityId",
                table: "VehicleModels");

            migrationBuilder.RenameColumn(
                name: "VehicleMakeEntityId",
                table: "VehicleModels",
                newName: "VehicleMakeId");

            migrationBuilder.AddColumn<int>(
                name: "VehicleMakeEntitysId",
                table: "VehicleModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleMakeEntitysId",
                table: "VehicleModels",
                column: "VehicleMakeEntitysId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeEntitysId",
                table: "VehicleModels",
                column: "VehicleMakeEntitysId",
                principalTable: "VehicleMakes",
                principalColumn: "Id");
        }
    }
}
