using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Apointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apointments_DoctorId",
                table: "Apointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Apointments_PatientId1",
                table: "Apointments",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Apointments_Doctors_DoctorId",
                table: "Apointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apointments_Patients_PatientId1",
                table: "Apointments",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apointments_Doctors_DoctorId",
                table: "Apointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apointments_Patients_PatientId1",
                table: "Apointments");

            migrationBuilder.DropIndex(
                name: "IX_Apointments_DoctorId",
                table: "Apointments");

            migrationBuilder.DropIndex(
                name: "IX_Apointments_PatientId1",
                table: "Apointments");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Apointments");
        }
    }
}
