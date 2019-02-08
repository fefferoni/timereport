using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeReport.Repository.Migrations
{
    public partial class SeedTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Background", "CreatedById", "CustomerId", "DateCreated", "DateModified", "EndDateTime", "Goal", "Name", "ProjectId", "StartDateTime", "TimeType" },
                values: new object[] { 1, "Testing of a new feature in our system.", null, null, new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053), new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053), new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), "Complete regression tests.", "White-box testing", null, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Background", "CreatedById", "CustomerId", "DateCreated", "DateModified", "EndDateTime", "Goal", "Name", "ProjectId", "StartDateTime", "TimeType" },
                values: new object[] { 2, "Dashboard needs lazy loading.", null, null, new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053), new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053), new DateTime(2019, 2, 15, 0, 0, 0, 0, DateTimeKind.Local), "Development complete.", "Lazy loading", null, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
