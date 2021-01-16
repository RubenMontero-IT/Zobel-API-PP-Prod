using Microsoft.EntityFrameworkCore.Migrations;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Migrations
{
    public partial class UpdatePerformanceParticipationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportElement_User_CreatedById",
                schema: "ppart",
                table: "ReportElement");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportElement_User_LastModifiedById",
                schema: "ppart",
                table: "ReportElement");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplateElement_User_CreatedById",
                schema: "ppart",
                table: "ReportTemplateElement");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplateElement_User_LastModifiedById",
                schema: "ppart",
                table: "ReportTemplateElement");

            migrationBuilder.RenameColumn(
                name: "LastModifiedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplateElement_LastModifiedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "IX_ReportTemplateElement_LastModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplateElement_CreatedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "IX_ReportTemplateElement_CreatedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "ppart",
                table: "ReportTemplate",
                newName: "CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_CreatedById",
                schema: "ppart",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_CreatedByID");

            migrationBuilder.RenameColumn(
                name: "ReportTemplateElementId",
                schema: "ppart",
                table: "ReportElement",
                newName: "ReportTemplateElementID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedById",
                schema: "ppart",
                table: "ReportElement",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "ppart",
                table: "ReportElement",
                newName: "CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportElement_ReportTemplateElementId",
                schema: "ppart",
                table: "ReportElement",
                newName: "IX_ReportElement_ReportTemplateElementID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportElement_LastModifiedById",
                schema: "ppart",
                table: "ReportElement",
                newName: "IX_ReportElement_LastModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportElement_CreatedById",
                schema: "ppart",
                table: "ReportElement",
                newName: "IX_ReportElement_CreatedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "ppart",
                table: "Report",
                newName: "CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Report_CreatedById",
                schema: "ppart",
                table: "Report",
                newName: "IX_Report_CreatedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportElement_User_CreatedByID",
                schema: "ppart",
                table: "ReportElement",
                column: "CreatedByID",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportElement_User_LastModifiedByID",
                schema: "ppart",
                table: "ReportElement",
                column: "LastModifiedByID",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplateElement_User_CreatedByID",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "CreatedByID",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplateElement_User_LastModifiedByID",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "LastModifiedByID",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportElement_User_CreatedByID",
                schema: "ppart",
                table: "ReportElement");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportElement_User_LastModifiedByID",
                schema: "ppart",
                table: "ReportElement");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplateElement_User_CreatedByID",
                schema: "ppart",
                table: "ReportTemplateElement");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplateElement_User_LastModifiedByID",
                schema: "ppart",
                table: "ReportTemplateElement");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "LastModifiedById");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplateElement_LastModifiedByID",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "IX_ReportTemplateElement_LastModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplateElement_CreatedByID",
                schema: "ppart",
                table: "ReportTemplateElement",
                newName: "IX_ReportTemplateElement_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                schema: "ppart",
                table: "ReportTemplate",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_CreatedByID",
                schema: "ppart",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_CreatedById");

            migrationBuilder.RenameColumn(
                name: "ReportTemplateElementID",
                schema: "ppart",
                table: "ReportElement",
                newName: "ReportTemplateElementId");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "ppart",
                table: "ReportElement",
                newName: "LastModifiedById");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                schema: "ppart",
                table: "ReportElement",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ReportElement_ReportTemplateElementID",
                schema: "ppart",
                table: "ReportElement",
                newName: "IX_ReportElement_ReportTemplateElementId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportElement_LastModifiedByID",
                schema: "ppart",
                table: "ReportElement",
                newName: "IX_ReportElement_LastModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_ReportElement_CreatedByID",
                schema: "ppart",
                table: "ReportElement",
                newName: "IX_ReportElement_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                schema: "ppart",
                table: "Report",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Report_CreatedByID",
                schema: "ppart",
                table: "Report",
                newName: "IX_Report_CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportElement_User_CreatedById",
                schema: "ppart",
                table: "ReportElement",
                column: "CreatedById",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportElement_User_LastModifiedById",
                schema: "ppart",
                table: "ReportElement",
                column: "LastModifiedById",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplateElement_User_CreatedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "CreatedById",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplateElement_User_LastModifiedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "LastModifiedById",
                principalSchema: "userm",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
