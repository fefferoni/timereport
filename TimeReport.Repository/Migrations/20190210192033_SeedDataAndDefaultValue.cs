using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeReport.Repository.Migrations
{
    public partial class SeedDataAndDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "TimeReports",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TimeReports",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Tasks",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Tasks",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Project",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Project",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Customers",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Customers",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Background", "CreatedById", "CustomerId", "EndDateTime", "Goal", "Name", "ProjectId", "StartDateTime", "TimeType" },
                values: new object[] { 1, "Testing of a new feature in our system.", null, null, new DateTime(2019, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Complete regression tests.", "White-box testing", null, new DateTime(2019, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Background", "CreatedById", "CustomerId", "EndDateTime", "Goal", "Name", "ProjectId", "StartDateTime", "TimeType" },
                values: new object[] { 2, "Dashboard needs lazy loading.", null, null, new DateTime(2019, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Development complete.", "Lazy loading", null, new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), 0 });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "Id", "Date", "DateCreated", "DateModified", "TaskId", "TimeWorked", "UserId" },
                values: new object[] { 1, new DateTime(2019, 2, 9, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), new DateTime(2019, 2, 10, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), new DateTime(2019, 2, 10, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), 1, 5.0, null });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "Id", "Date", "DateCreated", "DateModified", "TaskId", "TimeWorked", "UserId" },
                values: new object[] { 2, new DateTime(2019, 2, 8, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), new DateTime(2019, 2, 10, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), new DateTime(2019, 2, 10, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), 2, 2.0, null });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "Id", "Date", "DateCreated", "DateModified", "TaskId", "TimeWorked", "UserId" },
                values: new object[] { 3, new DateTime(2019, 2, 7, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), new DateTime(2019, 2, 10, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), new DateTime(2019, 2, 10, 19, 20, 33, 220, DateTimeKind.Utc).AddTicks(5009), 2, 1.5, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeReports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeReports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeReports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "TimeReports",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TimeReports",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Project",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Project",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");
        }
    }
}
