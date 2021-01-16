using AutoMapper;
using DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports;
using DhubSolutions.PerformanceParticipation.Application.Dtos.Reports;
using DhubSolutions.Reports.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;

namespace DhubSolutions.PerformanceParticipation.Api.Mappings.Reports
{
    public partial class ReportTemplateElementProfile : Profile
    {
        public ReportTemplateElementProfile()
        {
            CreateMap<ReportTemplateElementVM, ReportTemplateElementDto>()
              //Ignored Properties, because are auto calculated or not relevant for the reportTemplateElement
              .ForMember(rte => rte.Id, opt => opt.Ignore())

              .AfterMap((rtevm, rte) =>
              {
                  rte.Id = $"{Guid.NewGuid()}";
              });

            CreateMap<ReportTemplateElementDto, ReportTemplateElement>();

            CreateMap<ReportTemplateElement, ReportTemplateElementVM>()

                .ForMember(rtVm => rtVm.Config, opt => opt.Ignore())

                .AfterMap((rte, rteVm) =>
                {
                    rteVm.Config = JObject.Parse(rte.Config);
                });
        }
    }

}
