using AutoMapper;
using DhubSolutions.Reports.Domain.Entities;
using System;

namespace DhubSolutions.Reports.Domain.Services.Adapters
{
    public class ReportCreationProfile : Profile
    {
        public ReportCreationProfile()
        {
            CreateMap<ReportTemplate, Report>()
                .IncludeAllDerived()
                //Ignored Properties, because are auto calculated or not relevant for the report
                .ForMember(r => r.Data, opts => opts.Ignore())          //Auto calculated
                .ForMember(r => r.LastModified, opts => opts.Ignore())  //Auto calculated
                .ForMember(r => r.CreatedById, opts => opts.Ignore())   //Auto calculated
                .ForMember(r => r.CreatedBy, opts => opts.Ignore())     //Auto calculated
                .ForMember(r => r.CreationDate, opts => opts.Ignore())  //Auto calculated

                .ForMember(r => r.ReportTemplateId, opts => opts.MapFrom(rt => rt.Id))

                .AfterMap((template, report) =>
                {
                    //After finishing mapping we need to set some properties that must be calculated
                    report.Id = $"{Guid.NewGuid()}";
                    report.CreationDate = DateTime.Now;
                    report.LastModified = DateTime.Now;
                    report.ReportTemplate = template;
                    report.ReportTemplateId = template.Id;
                    report.UpdateUpReferences();
                });

            CreateMap<ReportTemplateElement, ReportElement>()
                .IncludeAllDerived()
                //Ignored Properties, because are auto calculated or not relevant for the reportElement
                .ForMember(re => re.Id, opts => opts.Ignore())                  //Auto calculated
                .ForMember(re => re.CreationDate, opts => opts.Ignore())        //Auto calculated
                .ForMember(re => re.LastModified, opts => opts.Ignore())        //Auto calculated
                .ForMember(re => re.CreatedBy, opts => opts.Ignore())           //Auto calculated
                .ForMember(re => re.CreatedById, opts => opts.Ignore())         //Auto calculated
                .ForMember(re => re.LastModifiedBy, opts => opts.Ignore())      //Auto calculated
                .ForMember(re => re.LastModifiedById, opts => opts.Ignore())    //Auto calculated

                .AfterMap((reportTemplateElement, ReportElement) =>
                {
                    //After finishing mapping we need to set some properties that must be calculated
                    ReportElement.Id = $"{Guid.NewGuid()}";
                    ReportElement.CreationDate = DateTime.Now;
                    ReportElement.LastModified = DateTime.Now;
                    ReportElement.ReportTemplateElement = reportTemplateElement;
                    ReportElement.ReportTemplateElementId = reportTemplateElement.Id;
                });
        }
    }


}
