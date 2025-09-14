using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemiv2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 49, 29, 550, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 49, 29, 550, DateTimeKind.Utc).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 49, 29, 550, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 49, 29, 550, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 49, 29, 550, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 49, 29, 550, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 49, 29, 550, DateTimeKind.Utc).AddTicks(9101));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 43, 23, 706, DateTimeKind.Utc).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 43, 23, 706, DateTimeKind.Utc).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 43, 23, 706, DateTimeKind.Utc).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 43, 23, 706, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 43, 23, 706, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 43, 23, 706, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 10, 43, 23, 706, DateTimeKind.Utc).AddTicks(292));
        }
    }
}
