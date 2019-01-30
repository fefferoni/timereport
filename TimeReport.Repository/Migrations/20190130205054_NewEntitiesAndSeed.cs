using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeReport.Repository.Migrations
{
    public partial class NewEntitiesAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimeType",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: true),
                    TimeWorked = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReport_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeReport_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Background", "CreatedById", "CustomerId", "DateCreated", "DateModified", "EndDateTime", "Goal", "Name", "ProjectId", "StartDateTime", "TimeType" },
                values: new object[] { 1, "Testing of a new feature in our system.", null, null, new DateTime(2019, 1, 30, 20, 50, 53, 766, DateTimeKind.Utc).AddTicks(5231), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Local), "Complete regression tests.", "White-box testing", null, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Background", "CreatedById", "CustomerId", "DateCreated", "DateModified", "EndDateTime", "Goal", "Name", "ProjectId", "StartDateTime", "TimeType" },
                values: new object[] { 2, "Dashboard needs lazy loading.", null, null, new DateTime(2019, 1, 30, 20, 50, 53, 769, DateTimeKind.Utc).AddTicks(3969), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 13, 0, 0, 0, 0, DateTimeKind.Local), "Development complete.", "Lazy loading", null, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedById",
                table: "Tasks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CustomerId",
                table: "Tasks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReport_TaskId",
                table: "TimeReport",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReport_UserId",
                table: "TimeReport",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedById",
                table: "Tasks",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Customer_CustomerId",
                table: "Tasks",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedById",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Customer_CustomerId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "TimeReport");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatedById",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CustomerId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Background",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TimeType",
                table: "Tasks");
        }
    }
}
