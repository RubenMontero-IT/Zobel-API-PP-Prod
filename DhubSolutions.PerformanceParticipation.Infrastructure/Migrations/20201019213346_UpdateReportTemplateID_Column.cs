using Microsoft.EntityFrameworkCore.Migrations;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Migrations
{
    public partial class UpdateReportTemplateID_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateID",
                schema: "ppart",
                table: "Report",
                newName: "ReportTemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_Report_TemplateID",
                schema: "ppart",
                table: "Report",
                newName: "IX_Report_ReportTemplateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportTemplateID",
                schema: "ppart",
                table: "Report",
                newName: "TemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ReportTemplateID",
                schema: "ppart",
                table: "Report",
                newName: "IX_Report_TemplateID");
        }
    }
}
