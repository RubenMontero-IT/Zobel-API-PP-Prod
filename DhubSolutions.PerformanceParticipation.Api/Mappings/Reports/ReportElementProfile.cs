using AutoMapper;
using DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports;
using DhubSolutions.PerformanceParticipation.Application.Dtos.Reports;
using DhubSolutions.Reports.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;

namespace DhubSolutions.PerformanceParticipation.Api.Mappings.Reports
{
    public partial class ReportTemplateElementProfile
    {
        public class ReportElementProfile : Profile
        {
            public ReportElementProfile()
            {
                CreateMap<ReportElement, ReportElementVM>()
                    .ForMember(dest => dest.Config, opt =>
                    {
                        opt.PreCondition(src => !string.IsNullOrEmpty(src.Config));
                        opt.MapFrom(src => JObject.Parse(src.Config));
                    });

                CreateMap<ReportElementVM, ReportElementDto>()
                   .AfterMap((src, dest) =>
                   {
                       //Add new ReportElement
                       if (dest.Id == null)
                           dest.Id = $"{Guid.NewGuid()}";
                   });

                CreateMap<ReportElementDto, ReportElement>()
                    .ForMember(dest => dest.Children, opt => opt.Ignore())
                    .ForMember(dest => dest.Config, opt =>
                    {
                        opt.PreCondition(src => src.Config != null);
                        opt.MapFrom(src => src.Config);
                    });

            }
        }
    }

}
