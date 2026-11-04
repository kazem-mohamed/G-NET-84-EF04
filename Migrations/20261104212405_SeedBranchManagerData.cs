using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace G_NET_84_EF04.Migrations
{
    /// <inheritdoc />
    public partial class SeedBranchManagerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "ALX-01", "Corniche Road, Alexandria", "Alexandria Branch", "01000000002" },
                    { "CAI-01", "Nile Street, Cairo", "Cairo Main Branch", "01000000001" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "BranchCode", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "CAI-01", "mona.manager@bank.example", "Mona Ahmed", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01111111111" },
                    { 2, "ALX-01", "manager@bank.example", "Nile Trading Manager", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01222222222" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "ALX-01");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "CAI-01");
        }
    }
}
