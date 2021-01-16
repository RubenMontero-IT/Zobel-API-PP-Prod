using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Migrations
{
    public partial class AddPerformanceParticipationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ppart");

            migrationBuilder.CreateTable(
                name: "ReportTemplate",
                schema: "ppart",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Metadata = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTemplate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReportTemplate_User",
                        column: x => x.CreatedById,
                        principalSchema: "userm",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                schema: "ppart",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Metadata = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationOptions = table.Column<string>(nullable: false),
                    TemplateID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Report_User",
                        column: x => x.CreatedById,
                        principalSchema: "userm",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_ReportTemplate",
                        column: x => x.TemplateID,
                        principalSchema: "ppart",
                        principalTable: "ReportTemplate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ReportTemplateElement",
                schema: "ppart",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedById = table.Column<string>(maxLength: 100, nullable: true),
                    LastModifiedById = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    Config = table.Column<string>(nullable: true),
                    ReportTemplateID = table.Column<string>(nullable: true),
                    ContainerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTemplateElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReportTemplatetElement_ReportTemplateElement",
                        column: x => x.ContainerID,
                        principalSchema: "ppart",
                        principalTable: "ReportTemplateElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportTemplateElement_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "userm",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportTemplateElement_User_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalSchema: "userm",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportTemplateElement_ReportTemplate",
                        column: x => x.ReportTemplateID,
                        principalSchema: "ppart",
                        principalTable: "ReportTemplate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportElement",
                schema: "ppart",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedById = table.Column<string>(maxLength: 100, nullable: true),
                    LastModifiedById = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    Config = table.Column<string>(nullable: true),
                    ReportID = table.Column<string>(nullable: true),
                    ReportTemplateElementId = table.Column<string>(nullable: true),
                    ContainerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReportElement_ReportElement",
                        column: x => x.ContainerID,
                        principalSchema: "ppart",
                        principalTable: "ReportElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportElement_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "userm",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportElement_User_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalSchema: "userm",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportElement_Report",
                        column: x => x.ReportID,
                        principalSchema: "ppart",
                        principalTable: "Report",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportElement_ReportTemplateElement",
                        column: x => x.ReportTemplateElementId,
                        principalSchema: "ppart",
                        principalTable: "ReportTemplateElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Report_CreatedById",
                schema: "ppart",
                table: "Report",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Report_TemplateID",
                schema: "ppart",
                table: "Report",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportElement_ContainerID",
                schema: "ppart",
                table: "ReportElement",
                column: "ContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportElement_CreatedById",
                schema: "ppart",
                table: "ReportElement",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportElement_LastModifiedById",
                schema: "ppart",
                table: "ReportElement",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportElement_ReportID",
                schema: "ppart",
                table: "ReportElement",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportElement_ReportTemplateElementId",
                schema: "ppart",
                table: "ReportElement",
                column: "ReportTemplateElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplate_CreatedById",
                schema: "ppart",
                table: "ReportTemplate",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplateElement_ContainerID",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "ContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplateElement_CreatedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplateElement_LastModifiedById",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplateElement_ReportTemplateID",
                schema: "ppart",
                table: "ReportTemplateElement",
                column: "ReportTemplateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportElement",
                schema: "ppart");

            migrationBuilder.DropTable(
                name: "Report",
                schema: "ppart");

            migrationBuilder.DropTable(
                name: "ReportTemplateElement",
                schema: "ppart");

            migrationBuilder.DropTable(
                name: "ReportTemplate",
                schema: "ppart");
        }
    }
}
