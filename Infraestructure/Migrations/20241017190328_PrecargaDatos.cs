using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class PrecargaDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "Address", "Company", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", "Marketing Co.", "igarcia@company.com", "Ignacio García", "123456789" },
                    { 2, "Avenida Real 456", "Redes Global", "lperez@company.com", "Luciana Pérez", "987654321" },
                    { 3, "Boulevard Principal 789", "SEO Experts", "msosa@company.com", "Maximiliano Sosa", "123123123" },
                    { 4, "Calle Secundaria 321", "MediaPlus", "mramirez@company.com", "Marta Ramírez", "456456456" },
                    { 5, "Camino Real 654", "PPC Boosters", "rlopez@company.com", "Ramiro López", "654654654" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "CampaignTypeID", "ClientID", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { "23a3bf1b-41e3-4340-a0e8-31ca67b9e90b", 2, 5, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile App Development", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "308667d3-5446-453d-8738-fe3d40c568ba", 3, 3, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Social Media Strategy", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4c1dcab7-160d-4f5e-9590-e8c387365022", 3, 2, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Market Research", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "69cd700c-a8f0-475f-ad75-464aa64f1e74", 4, 4, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Email Automation", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6aa71c8e-e0a4-4dce-8491-9528c404f7bc", 2, 5, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PPC Advertising", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "780e196c-f428-481f-a84c-2d8f25712b34", 2, 1, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desarrollo WEB", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "7b86d9c1-6674-4bfe-ace1-d32dc3242c27", 3, 2, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Campaña Redes Sociales", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "80d7a206-1135-4567-9ca2-a523c57be557", 4, 3, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rebranding", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9450846e-3a7a-4616-a406-fbaa188e1f06", 1, 1, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Optimización SEO", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9537adbf-2b27-4602-aa51-013d6e330231", 1, 1, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Generation Campaign", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "97a30cd1-4461-418d-93ad-87e2f77adece", 1, 4, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Content Marketing", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9d82f536-3945-42c7-9cea-4db15aa90bb8", 2, 3, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estrategia PPC", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c190deaf-f11e-4bf0-88b7-09748882be67", 1, 1, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Redesign Web", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d0d20061-bbb8-41b4-81e6-7eb7d33ab664", 4, 4, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Campaña Email Marketing", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "f2dab425-638d-41ec-9064-3caaccaed69c", 2, 2, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEO Campaign", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "23a3bf1b-41e3-4340-a0e8-31ca67b9e90b");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "308667d3-5446-453d-8738-fe3d40c568ba");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "4c1dcab7-160d-4f5e-9590-e8c387365022");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "69cd700c-a8f0-475f-ad75-464aa64f1e74");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "6aa71c8e-e0a4-4dce-8491-9528c404f7bc");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "780e196c-f428-481f-a84c-2d8f25712b34");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "7b86d9c1-6674-4bfe-ace1-d32dc3242c27");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "80d7a206-1135-4567-9ca2-a523c57be557");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "9450846e-3a7a-4616-a406-fbaa188e1f06");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "9537adbf-2b27-4602-aa51-013d6e330231");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "97a30cd1-4461-418d-93ad-87e2f77adece");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "9d82f536-3945-42c7-9cea-4db15aa90bb8");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "c190deaf-f11e-4bf0-88b7-09748882be67");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "d0d20061-bbb8-41b4-81e6-7eb7d33ab664");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: "f2dab425-638d-41ec-9064-3caaccaed69c");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
