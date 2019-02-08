using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeReport.Repository.Migrations
{
    public partial class RemovedDbSetsInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedById",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Customers_CustomerId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Project_ProjectId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeReports_Tasks_TaskId",
                table: "TimeReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeReports_AspNetUsers_UserId",
                table: "TimeReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeReports",
                table: "TimeReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "TimeReports",
                newName: "TimeReport");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_TimeReports_UserId",
                table: "TimeReport",
                newName: "IX_TimeReport_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeReports_TaskId",
                table: "TimeReport",
                newName: "IX_TimeReport_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "Task",
                newName: "IX_Task_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CustomerId",
                table: "Task",
                newName: "IX_Task_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CreatedById",
                table: "Task",
                newName: "IX_Task_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeReport",
                table: "TimeReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 2, 1, 21, 26, 0, 260, DateTimeKind.Utc).AddTicks(4826), new DateTime(2019, 2, 1, 21, 26, 0, 260, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 2, 1, 21, 26, 0, 260, DateTimeKind.Utc).AddTicks(4826), new DateTime(2019, 2, 1, 21, 26, 0, 260, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AspNetUsers_CreatedById",
                table: "Task",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Customer_CustomerId",
                table: "Task",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeReport_Task_TaskId",
                table: "TimeReport",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeReport_AspNetUsers_UserId",
                table: "TimeReport",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AspNetUsers_CreatedById",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Customer_CustomerId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeReport_Task_TaskId",
                table: "TimeReport");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeReport_AspNetUsers_UserId",
                table: "TimeReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeReport",
                table: "TimeReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "TimeReport",
                newName: "TimeReports");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_TimeReport_UserId",
                table: "TimeReports",
                newName: "IX_TimeReports_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeReport_TaskId",
                table: "TimeReports",
                newName: "IX_TimeReports_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_CustomerId",
                table: "Tasks",
                newName: "IX_Tasks_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_CreatedById",
                table: "Tasks",
                newName: "IX_Tasks_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeReports",
                table: "TimeReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053), new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053), new DateTime(2019, 2, 1, 21, 9, 15, 608, DateTimeKind.Utc).AddTicks(7053) });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedById",
                table: "Tasks",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Customers_CustomerId",
                table: "Tasks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Project_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeReports_Tasks_TaskId",
                table: "TimeReports",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeReports_AspNetUsers_UserId",
                table: "TimeReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
