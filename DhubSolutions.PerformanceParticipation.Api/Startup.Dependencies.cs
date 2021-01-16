using DhubSolutions.Common.Application.Services.Admin;
using DhubSolutions.Common.Application.Services.Admin.Base;
using DhubSolutions.Common.Domain.Repositories.Admin;
using DhubSolutions.Core.Application.Adapters;
using DhubSolutions.Core.Domain.Adapters;
using DhubSolutions.Core.Domain.Data;
using DhubSolutions.Core.Infrastructure.Data;
using DhubSolutions.PerformanceParticipation.Application.Services.DataUploader;
using DhubSolutions.PerformanceParticipation.Application.Services.DataUploader.Base;
using DhubSolutions.PerformanceParticipation.Application.Services.Reports;
using DhubSolutions.PerformanceParticipation.Application.Services.Reports.Base;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.DataUploader;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Context;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Admin;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.DataUploader;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Reports;
using DhubSolutions.Reports.Domain.Services;
using DhubSolutions.Reports.Domain.Services.Base;
using DhubSolutions.Reports.Domain.Services.InstructionProcessors.Factories;
using DhubSolutions.Reports.Domain.Services.InstructionProcessors.Factories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DhubSolutions.PerformanceParticipationReport.Api
{
    public partial class Startup
    {
        public void ConfigureDependencies(IConfiguration configuration, IServiceCollection services)
        {
            #region DhubSolutions.Core 

            services
               .AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork<PerformanceParticipationDbContext>>()
               .AddScoped<IEntityFrameworkUnitOfWork, EntityFrameworkUnitOfWork<PerformanceParticipationDbContext>>()
               .AddScoped<ITypeAdapter, AutoMapperTypeAdapter>();

            #endregion

            #region DhubSolutions.Core.Report

            services
               .AddScoped<IReportManagerService, ReportManagerService>()
               .AddScoped<IInstructionProcessorFactoryProvider, InstructionProcessorFactoryProvider>()
               .AddScoped<IInstructionProcessorFactoryProxy, InstructionProcessorFactoryProxy>()
               .AddScoped<IReportDataRepository, ReportDataRepository>(sp => new ReportDataRepository(configuration)
               );

            services
              .RegisterAllTypes<IInstructionProcessorFactory>(assemblies.ToArray(), ServiceLifetime.Scoped);


            #endregion

            #region DhubSolutions.Core.Common

            services
               .AddScoped<IOrganizationService, OrganizationService>()
               .AddScoped<IOrganizationRoleService, OrganizationRoleService>();

            services
                .AddScoped<IOrganizationRepository, OrganizationRepository>()
                .AddScoped<IOrganizationRoleRepository, OrganizationRoleRepository>();

            #endregion

            #region DhubSolutions.PerformanceParticipation

            services
                .AddScoped<IReportService, ReportService>()
                .AddScoped<IReportTemplateService, ReportTemplateService>();

            services
                .AddScoped<IReportRepository, ReportRepository>()
                .AddScoped<IReportElementRepository, ReportElementRepository>()
                .AddScoped<IReportTemplateRepository, ReportTemplateRepository>()
                .AddScoped<IReportTemplateElementRepository, ReportTemplateElementRepository>();

            #endregion

            #region DataUploader

            services
                .AddScoped<IDataUploaderRepository, DataUploaderRepository>()
                .AddScoped<IDataUploaderService, DataUploaderService>();

            #endregion

        }
    }
}