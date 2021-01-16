using AutoMapper;
using DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports;
using DhubSolutions.PerformanceParticipation.Application.Dtos.Reports;
using DhubSolutions.Reports.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;

namespace DhubSolutions.PerformanceParticipation.Api.Mappings.Reports
{
    public class ReportTemplateProfile : Profile
    {
        public ReportTemplateProfile()
        {
            CreateMap<ReportTemplateVM, ReportTemplateDto>()
                .ForMember(rt => rt.Id, opt => opt.Ignore())

                .AfterMap((rtvm, rt) =>
                {
                    rt.Id = $"{Guid.NewGuid()}";
                });

            CreateMap<ReportTemplateDto, ReportTemplate>();

            CreateMap<ReportTemplate, ShortReportTemplateVM>();

            CreateMap<ReportTemplate, ReportTemplateVM>()
               .ForMember(rtvm => rtvm.Data, opt => opt.Ignore())
               .ForMember(rtvm => rtvm.Metadata, opt => opt.Ignore())

               .AfterMap((template, templateVM) =>
               {
                   templateVM.Data = JObject.Parse(template.Data);
                   templateVM.Metadata = JObject.Parse(template.Metadata);
               });
        }
    }
}
