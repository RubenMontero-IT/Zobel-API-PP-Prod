using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "userm");

            //migrationBuilder.EnsureSchema(
            //    name: "app");

            //migrationBuilder.EnsureSchema(
            //    name: "gral");

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SystemGroup",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Code = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SystemGroup", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Apps",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        APPID = table.Column<string>(maxLength: 100, nullable: false),
            //        AppCode = table.Column<string>(maxLength: 50, nullable: false),
            //        AppName = table.Column<string>(maxLength: 50, nullable: false),
            //        Description = table.Column<string>(maxLength: 250, nullable: true),
            //        AppIsWeb = table.Column<bool>(nullable: false),
            //        AppURL = table.Column<string>(maxLength: 250, nullable: true),
            //        IsEnable = table.Column<bool>(nullable: false),
            //        AppLogo = table.Column<string>(maxLength: 250, nullable: true),
            //        AlternativeName = table.Column<string>(maxLength: 250, nullable: true),
            //        InternalUse = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Apps", x => x.APPID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LogUserByApp",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        LogUAID = table.Column<string>(maxLength: 100, nullable: false),
            //        USERID = table.Column<string>(maxLength: 100, nullable: false),
            //        APPID = table.Column<string>(maxLength: 100, nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Description = table.Column<string>(maxLength: 150, nullable: true),
            //        ActionID = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LogUserByApp", x => x.LogUAID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ResourceType",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        ResourceTypeID = table.Column<string>(maxLength: 100, nullable: false),
            //        ResourceTypeName = table.Column<string>(maxLength: 50, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ResourceType", x => x.ResourceTypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Country",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        CountryID = table.Column<string>(maxLength: 100, nullable: false),
            //        CountryAcronym = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Country", x => x.CountryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Currency",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        CurrencyID = table.Column<string>(maxLength: 100, nullable: false),
            //        CurrencyValue = table.Column<string>(maxLength: 5, nullable: false),
            //        Description = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Currency", x => x.CurrencyID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FinancingRepayment",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(maxLength: 150, nullable: true),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FinancingRepayment", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Industry",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        IndustryID = table.Column<string>(maxLength: 100, nullable: false),
            //        IndustryValue = table.Column<string>(maxLength: 150, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Industry", x => x.IndustryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProcessType",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        ProcessTypeID = table.Column<string>(maxLength: 100, nullable: false),
            //        ProcessTypeValue = table.Column<string>(maxLength: 100, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProcessType", x => x.ProcessTypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SaleReason",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        SaleReasonID = table.Column<string>(maxLength: 100, nullable: false),
            //        SaleReasonValue = table.Column<string>(maxLength: 150, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SaleReason", x => x.SaleReasonID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SegmentProductCategory",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        SegProdCatID = table.Column<string>(maxLength: 100, nullable: false),
            //        SegProdCatValue = table.Column<string>(maxLength: 150, nullable: false),
            //        Description = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SegmentProductCategory", x => x.SegProdCatID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Seller",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        SellerID = table.Column<string>(maxLength: 100, nullable: false),
            //        SellerValue = table.Column<string>(maxLength: 150, nullable: false),
            //        Description = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Seller", x => x.SellerID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Session",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        SessionID = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
            //        USERID = table.Column<string>(maxLength: 100, nullable: false),
            //        Access = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Data = table.Column<string>(type: "text", nullable: true),
            //        Expires = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Session", x => x.SessionID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SPAMechanism",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(maxLength: 50, nullable: true),
            //        Description = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SPAMechanism", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Status",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        StatusID = table.Column<string>(maxLength: 100, nullable: false),
            //        StatusValue = table.Column<string>(maxLength: 50, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Status", x => x.StatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Tag",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        TagID = table.Column<string>(maxLength: 100, nullable: false),
            //        TagName = table.Column<string>(maxLength: 250, nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        TagParent = table.Column<string>(maxLength: 100, nullable: true),
            //        CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Author = table.Column<int>(nullable: true),
            //        IsType = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tags", x => x.TagID);
            //        table.ForeignKey(
            //            name: "FK_Tag_Tag",
            //            column: x => x.TagParent,
            //            principalSchema: "gral",
            //            principalTable: "Tag",
            //            principalColumn: "TagID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeOfDisclosure",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(maxLength: 50, nullable: true),
            //        Description = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeOfDisclosure", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeOfPurchase",
            //    schema: "gral",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(maxLength: 50, nullable: true),
            //        Description = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeOfPurchase", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Permission",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        PermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        PermissionRelevance = table.Column<string>(maxLength: 50, nullable: false),
            //        PermissionCode = table.Column<string>(maxLength: 50, nullable: true),
            //        Style = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Permission", x => x.PermissionID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleType",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        RTID = table.Column<string>(maxLength: 100, nullable: false),
            //        RoleTypeName = table.Column<string>(maxLength: 50, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleType", x => x.RTID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        RoleId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppSetting",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        SettingID = table.Column<string>(maxLength: 100, nullable: false),
            //        SettingName = table.Column<string>(maxLength: 50, nullable: false),
            //        APPID = table.Column<string>(maxLength: 100, nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        DefaultValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppSettings", x => x.SettingID);
            //        table.ForeignKey(
            //            name: "FK_AppSetting_Apps",
            //            column: x => x.APPID,
            //            principalSchema: "app",
            //            principalTable: "Apps",
            //            principalColumn: "APPID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Feature",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        FeatureID = table.Column<string>(maxLength: 100, nullable: false),
            //        ResourceTypeID = table.Column<string>(maxLength: 100, nullable: false),
            //        FeatureName = table.Column<string>(maxLength: 50, nullable: true),
            //        Description = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Feature_1", x => x.FeatureID);
            //        table.ForeignKey(
            //            name: "FK_Feature_ResourceType",
            //            column: x => x.ResourceTypeID,
            //            principalSchema: "app",
            //            principalTable: "ResourceType",
            //            principalColumn: "ResourceTypeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Resource",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        ResourceID = table.Column<string>(maxLength: 100, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true),
            //        ResourceType = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Resource", x => x.ResourceID);
            //        table.ForeignKey(
            //            name: "FK_Resource_ResourceType",
            //            column: x => x.ResourceType,
            //            principalSchema: "app",
            //            principalTable: "ResourceType",
            //            principalColumn: "ResourceTypeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleValue",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(maxLength: 50, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true),
            //        RTID = table.Column<string>(maxLength: 100, nullable: true),
            //        IsDefault = table.Column<bool>(nullable: false),
            //        ContactEmail = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleValues", x => x.RVID);
            //        table.ForeignKey(
            //            name: "FK_RoleValue_RoleType",
            //            column: x => x.RTID,
            //            principalSchema: "userm",
            //            principalTable: "RoleType",
            //            principalColumn: "RTID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppSettingsMV",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        AppSettingsMVID = table.Column<string>(maxLength: 100, nullable: false),
            //        SettingID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(unicode: false, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppSettingsMV", x => new { x.SettingID, x.AppSettingsMVID });
            //        table.ForeignKey(
            //            name: "FK_AppSettingsMV_AppSetting",
            //            column: x => x.SettingID,
            //            principalSchema: "app",
            //            principalTable: "AppSetting",
            //            principalColumn: "SettingID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CommentedResource",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        CommentedResourceID = table.Column<string>(maxLength: 100, nullable: false),
            //        ResourceID = table.Column<string>(maxLength: 100, nullable: false),
            //        CommentID = table.Column<string>(maxLength: 100, nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true),
            //        FeatureID = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CommentedResource", x => x.CommentedResourceID);
            //        table.ForeignKey(
            //            name: "FK_CommentedResource_Feature",
            //            column: x => x.FeatureID,
            //            principalSchema: "app",
            //            principalTable: "Feature",
            //            principalColumn: "FeatureID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_CommentedResource_Resource",
            //            column: x => x.ResourceID,
            //            principalSchema: "app",
            //            principalTable: "Resource",
            //            principalColumn: "ResourceID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Organization",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false),
            //        LucanetId = table.Column<int>(nullable: true),
            //        OrganizationName = table.Column<string>(maxLength: 50, nullable: false),
            //        OrganizationDescription = table.Column<string>(maxLength: 150, nullable: true),
            //        ResourceID = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Organization", x => x.ORGID);
            //        table.ForeignKey(
            //            name: "FK_Organization_Resource",
            //            column: x => x.ResourceID,
            //            principalSchema: "app",
            //            principalTable: "Resource",
            //            principalColumn: "ResourceID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "User",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(maxLength: 100, nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        Login = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        InitDate = table.Column<DateTime>(type: "date", nullable: false),
            //        Active = table.Column<bool>(nullable: false),
            //        DeskPhone = table.Column<string>(maxLength: 50, nullable: true),
            //        Internal = table.Column<bool>(nullable: false),
            //        UserPicture = table.Column<string>(nullable: false),
            //        IsADemoUser = table.Column<bool>(nullable: false),
            //        ResourceID = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_User_Resource",
            //            column: x => x.ResourceID,
            //            principalSchema: "app",
            //            principalTable: "Resource",
            //            principalColumn: "ResourceID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SharedComment",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        SharedCommentID = table.Column<string>(maxLength: 100, nullable: false),
            //        CommentID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ReadOnly = table.Column<bool>(nullable: true),
            //        Date = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SharedComment", x => x.SharedCommentID);
            //        table.ForeignKey(
            //            name: "FK_SharedComment_RoleValue",
            //            column: x => x.RVID,
            //            principalSchema: "userm",
            //            principalTable: "RoleValue",
            //            principalColumn: "RVID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrganizationRole",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        OrganizationRoleID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false),
            //        IsDefault = table.Column<bool>(nullable: false),
            //        Description = table.Column<string>(maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrganizationRole", x => x.OrganizationRoleID);
            //        table.UniqueConstraint("AK_OrganizationRole_RVID_ORGID", x => new { x.RVID, x.ORGID });
            //        table.ForeignKey(
            //            name: "FK_OrganizationRole_Organization",
            //            column: x => x.ORGID,
            //            principalSchema: "userm",
            //            principalTable: "Organization",
            //            principalColumn: "ORGID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrganizationRole_RoleValue",
            //            column: x => x.RVID,
            //            principalSchema: "userm",
            //            principalTable: "RoleValue",
            //            principalColumn: "RVID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(nullable: false),
            //        ProviderKey = table.Column<string>(nullable: false),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppMaxPermission",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        APPID = table.Column<string>(nullable: false),
            //        USERID = table.Column<string>(nullable: false),
            //        MaxPermission = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppMaxPermission", x => new { x.APPID, x.USERID, x.MaxPermission });
            //        table.ForeignKey(
            //            name: "FK_AppMaxPermission_Apps",
            //            column: x => x.APPID,
            //            principalSchema: "app",
            //            principalTable: "Apps",
            //            principalColumn: "APPID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AppMaxPermission_Permission",
            //            column: x => x.MaxPermission,
            //            principalSchema: "userm",
            //            principalTable: "Permission",
            //            principalColumn: "PermissionID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AppMaxPermission_User_USERID",
            //            column: x => x.USERID,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppSettingsByUser",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        AppSettingsByUserID = table.Column<string>(maxLength: 100, nullable: false),
            //        SettingID = table.Column<string>(maxLength: 100, nullable: false),
            //        USERID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppSettingsByUser", x => x.AppSettingsByUserID);
            //        table.ForeignKey(
            //            name: "FK_AppSettingsByUser_AppSetting",
            //            column: x => x.SettingID,
            //            principalSchema: "app",
            //            principalTable: "AppSetting",
            //            principalColumn: "SettingID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AppSettingsByUser_User",
            //            column: x => x.USERID,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PasswordRequests",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        REQUESTID = table.Column<string>(maxLength: 255, nullable: false),
            //        USERID = table.Column<string>(maxLength: 100, nullable: false),
            //        RequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Active = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PasswordRequests", x => x.REQUESTID);
            //        table.ForeignKey(
            //            name: "FK_PasswordRequests_User",
            //            column: x => x.USERID,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SystemGroupMemberShip",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        SystemGroupId = table.Column<string>(nullable: true),
            //        OrganizationRoleId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SystemGroupMemberShip", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_SystemGroupMemberShip_OrganizationRole_OrganizationRoleId",
            //            column: x => x.OrganizationRoleId,
            //            principalSchema: "userm",
            //            principalTable: "OrganizationRole",
            //            principalColumn: "OrganizationRoleID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_SystemGroupMemberShip_SystemGroup_SystemGroupId",
            //            column: x => x.SystemGroupId,
            //            principalTable: "SystemGroup",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppSettingRoleVOrg",
            //    schema: "app",
            //    columns: table => new
            //    {
            //        AppSettingRoleVOrgID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false),
            //        SettingID = table.Column<string>(maxLength: 100, nullable: false),
            //        Value = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppSettingRoleVOrg", x => x.AppSettingRoleVOrgID);
            //        table.ForeignKey(
            //            name: "FK_AppSettingRoleVOrg_AppSetting",
            //            column: x => x.SettingID,
            //            principalSchema: "app",
            //            principalTable: "AppSetting",
            //            principalColumn: "SettingID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AppSettingRoleVOrg_OrganizationRole",
            //            columns: x => new { x.RVID, x.ORGID },
            //            principalSchema: "userm",
            //            principalTable: "OrganizationRole",
            //            principalColumns: new[] { "RVID", "ORGID" },
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DefaultRolePermission",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        DefaultRolePermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false),
            //        PermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        Active = table.Column<bool>(nullable: false),
            //        ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ModificationUser = table.Column<string>(maxLength: 100, nullable: false),
            //        Description = table.Column<string>(maxLength: 250, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DefaultRolePermission", x => x.DefaultRolePermissionID);
            //        table.ForeignKey(
            //            name: "FK_DefaultRolePermission_User",
            //            column: x => x.ModificationUser,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DefaultRolePermission_Permission",
            //            column: x => x.PermissionID,
            //            principalSchema: "userm",
            //            principalTable: "Permission",
            //            principalColumn: "PermissionID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DefaultRolePermission_OrganizationRole",
            //            columns: x => new { x.RVID, x.ORGID },
            //            principalSchema: "userm",
            //            principalTable: "OrganizationRole",
            //            principalColumns: new[] { "RVID", "ORGID" },
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleAppPermission",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        RoleAppPermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false),
            //        APPID = table.Column<string>(maxLength: 100, nullable: false),
            //        PermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        WithGrant = table.Column<bool>(nullable: false),
            //        Denied = table.Column<bool>(nullable: false),
            //        ExpirationDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleAppPermission", x => x.RoleAppPermissionID);
            //        table.ForeignKey(
            //            name: "FK_RoleAppPermission_Apps",
            //            column: x => x.APPID,
            //            principalSchema: "app",
            //            principalTable: "Apps",
            //            principalColumn: "APPID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_RoleAppPermission_Permission",
            //            column: x => x.PermissionID,
            //            principalSchema: "userm",
            //            principalTable: "Permission",
            //            principalColumn: "PermissionID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_RoleAppPermission_OrganizationRole",
            //            columns: x => new { x.RVID, x.ORGID },
            //            principalSchema: "userm",
            //            principalTable: "OrganizationRole",
            //            principalColumns: new[] { "RVID", "ORGID" },
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleFilePermission",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        FileID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false),
            //        PermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        WithGrant = table.Column<bool>(nullable: false),
            //        Denied = table.Column<bool>(nullable: false),
            //        ExpirationDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleFilePermission_1", x => new { x.RVID, x.ORGID, x.PermissionID, x.FileID });
            //        table.ForeignKey(
            //            name: "FK_RoleFilePermission_OrganizationRole_FileID",
            //            column: x => x.FileID,
            //            principalSchema: "userm",
            //            principalTable: "OrganizationRole",
            //            principalColumn: "OrganizationRoleID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_RoleFilePermission_Permission_PermissionID",
            //            column: x => x.PermissionID,
            //            principalSchema: "userm",
            //            principalTable: "Permission",
            //            principalColumn: "PermissionID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleProjectPermission",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        RoleProjectPermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false),
            //        ProjectID = table.Column<string>(maxLength: 100, nullable: false),
            //        PermissionID = table.Column<string>(maxLength: 100, nullable: false),
            //        WithGrant = table.Column<bool>(nullable: false),
            //        Denied = table.Column<bool>(nullable: false),
            //        ExpirationDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleProjectPermission", x => x.RoleProjectPermissionID);
            //        table.ForeignKey(
            //            name: "FK_RoleProjectPermission_Permission",
            //            column: x => x.PermissionID,
            //            principalSchema: "userm",
            //            principalTable: "Permission",
            //            principalColumn: "PermissionID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_RoleProjectPermission_OrganizationRole",
            //            columns: x => new { x.RVID, x.ORGID },
            //            principalSchema: "userm",
            //            principalTable: "OrganizationRole",
            //            principalColumns: new[] { "RVID", "ORGID" },
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRoleOrg",
            //    schema: "userm",
            //    columns: table => new
            //    {
            //        UserRoleOrgID = table.Column<string>(maxLength: 100, nullable: false),
            //        USERID = table.Column<string>(maxLength: 100, nullable: false),
            //        RVID = table.Column<string>(maxLength: 100, nullable: false),
            //        ORGID = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRoleOrg", x => x.UserRoleOrgID);
            //        table.ForeignKey(
            //            name: "FK_UserRoleOrg_User",
            //            column: x => x.USERID,
            //            principalSchema: "userm",
            //            principalTable: "User",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_UserRoleOrg_OrganizationRole",
            //            columns: x => new { x.RVID, x.ORGID },
            //            principalSchema: "userm",
            //            principalTable: "OrganizationRole",
            //            principalColumns: new[] { "RVID", "ORGID" },
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SystemGroupMemberShip_OrganizationRoleId",
            //    table: "SystemGroupMemberShip",
            //    column: "OrganizationRoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SystemGroupMemberShip_SystemGroupId",
            //    table: "SystemGroupMemberShip",
            //    column: "SystemGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppMaxPermission_MaxPermission",
            //    schema: "app",
            //    table: "AppMaxPermission",
            //    column: "MaxPermission");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppMaxPermission_USERID",
            //    schema: "app",
            //    table: "AppMaxPermission",
            //    column: "USERID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppSetting_APPID",
            //    schema: "app",
            //    table: "AppSetting",
            //    column: "APPID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppSettingRoleVOrg_SettingID",
            //    schema: "app",
            //    table: "AppSettingRoleVOrg",
            //    column: "SettingID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppSettingRoleVOrg",
            //    schema: "app",
            //    table: "AppSettingRoleVOrg",
            //    columns: new[] { "RVID", "ORGID", "SettingID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppSettingsByUser_USERID",
            //    schema: "app",
            //    table: "AppSettingsByUser",
            //    column: "USERID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppSettingsByUser",
            //    schema: "app",
            //    table: "AppSettingsByUser",
            //    columns: new[] { "SettingID", "USERID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_CommentedResource_FeatureID",
            //    schema: "app",
            //    table: "CommentedResource",
            //    column: "FeatureID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CommentedResource",
            //    schema: "app",
            //    table: "CommentedResource",
            //    columns: new[] { "ResourceID", "CommentID", "FeatureID" },
            //    unique: true,
            //    filter: "[FeatureID] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Feature_ResourceTypeID",
            //    schema: "app",
            //    table: "Feature",
            //    column: "ResourceTypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Resource_ResourceType",
            //    schema: "app",
            //    table: "Resource",
            //    column: "ResourceType");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SharedComment_RVID",
            //    schema: "app",
            //    table: "SharedComment",
            //    column: "RVID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SharedComment",
            //    schema: "app",
            //    table: "SharedComment",
            //    columns: new[] { "CommentID", "RVID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tag_TagParent",
            //    schema: "gral",
            //    table: "Tag",
            //    column: "TagParent");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DefaultRolePermission_ModificationUser",
            //    schema: "userm",
            //    table: "DefaultRolePermission",
            //    column: "ModificationUser");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DefaultRolePermission_PermissionID",
            //    schema: "userm",
            //    table: "DefaultRolePermission",
            //    column: "PermissionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DefaultRolePermission",
            //    schema: "userm",
            //    table: "DefaultRolePermission",
            //    columns: new[] { "RVID", "ORGID", "PermissionID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Organization_ResourceID",
            //    schema: "userm",
            //    table: "Organization",
            //    column: "ResourceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrganizationRole_ORGID",
            //    schema: "userm",
            //    table: "OrganizationRole",
            //    column: "ORGID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrganizationRole",
            //    schema: "userm",
            //    table: "OrganizationRole",
            //    columns: new[] { "RVID", "ORGID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PasswordRequests_USERID",
            //    schema: "userm",
            //    table: "PasswordRequests",
            //    column: "USERID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleAppPermission_APPID",
            //    schema: "userm",
            //    table: "RoleAppPermission",
            //    column: "APPID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleAppPermission_PermissionID",
            //    schema: "userm",
            //    table: "RoleAppPermission",
            //    column: "PermissionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleAppPermission",
            //    schema: "userm",
            //    table: "RoleAppPermission",
            //    columns: new[] { "RVID", "ORGID", "APPID", "PermissionID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleFilePermission_FileID",
            //    schema: "userm",
            //    table: "RoleFilePermission",
            //    column: "FileID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleFilePermission_PermissionID",
            //    schema: "userm",
            //    table: "RoleFilePermission",
            //    column: "PermissionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleProjectPermission_PermissionID",
            //    schema: "userm",
            //    table: "RoleProjectPermission",
            //    column: "PermissionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleProjectPermission",
            //    schema: "userm",
            //    table: "RoleProjectPermission",
            //    columns: new[] { "RVID", "ORGID", "ProjectID", "PermissionID" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleValue_RTID",
            //    schema: "userm",
            //    table: "RoleValue",
            //    column: "RTID");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    schema: "userm",
            //    table: "User",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    schema: "userm",
            //    table: "User",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_User_ResourceID",
            //    schema: "userm",
            //    table: "User",
            //    column: "ResourceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRoleOrg_RVID_ORGID",
            //    schema: "userm",
            //    table: "UserRoleOrg",
            //    columns: new[] { "RVID", "ORGID" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRoleOrg",
            //    schema: "userm",
            //    table: "UserRoleOrg",
            //    columns: new[] { "USERID", "RVID", "ORGID" },
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "SystemGroupMemberShip");

            //migrationBuilder.DropTable(
            //    name: "AppMaxPermission",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "AppSettingRoleVOrg",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "AppSettingsByUser",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "AppSettingsMV",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "CommentedResource",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "LogUserByApp",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "SharedComment",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "Country",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "Currency",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "FinancingRepayment",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "Industry",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "ProcessType",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "SaleReason",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "SegmentProductCategory",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "Seller",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "Session",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "SPAMechanism",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "Status",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "Tag",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "TypeOfDisclosure",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "TypeOfPurchase",
            //    schema: "gral");

            //migrationBuilder.DropTable(
            //    name: "DefaultRolePermission",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "PasswordRequests",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "RoleAppPermission",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "RoleFilePermission",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "RoleProjectPermission",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "UserRoleOrg",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "SystemGroup");

            //migrationBuilder.DropTable(
            //    name: "AppSetting",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "Feature",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "Permission",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "User",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "OrganizationRole",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "Apps",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "Organization",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "RoleValue",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "Resource",
            //    schema: "app");

            //migrationBuilder.DropTable(
            //    name: "RoleType",
            //    schema: "userm");

            //migrationBuilder.DropTable(
            //    name: "ResourceType",
            //    schema: "app");
        }
    }
}
