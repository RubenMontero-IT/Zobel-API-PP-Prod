using AutoMapper;
using DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports;
using DhubSolutions.PerformanceParticipation.Application.Dtos.Reports;
using DhubSolutions.Reports.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace DhubSolutions.PerformanceParticipation.Api.Mappings.Reports
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ShortReportVM>()
                .ForMember(rvm => rvm.CreatedBy, opt => opt.MapFrom(r => r.CreatedBy.UserName))
                .ForMember(rvm => rvm.Organization, opt => opt.Ignore())

                .AfterMap((report, reportShortVM) =>
                {
                    reportShortVM.Organization = $"{JObject.Parse(report.Metadata)["organization"]}";
                });

            CreateMap<Report, ReportVM>()
               .ForMember(rVm => rVm.Data, opt => opt.Ignore())
               .ForMember(rVm => rVm.Metadata, opt => opt.Ignore())
               .ForMember(rvm => rvm.CreatedBy, opt => opt.MapFrom(r => r.CreatedBy.UserName))

               .AfterMap((report, reportVM) =>
                {
                    reportVM.Data = JObject.Parse(report.Data);
                    reportVM.Metadata = JObject.Parse(report.Metadata);
                });

            CreateMap<ReportContentVM, ReportContentDto>();
        }
    }
}
