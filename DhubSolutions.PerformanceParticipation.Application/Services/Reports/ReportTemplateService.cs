using DhubSolutions.Core.Application.Services;
using DhubSolutions.Core.Domain.Adapters;
using DhubSolutions.Core.Domain.Data;
using DhubSolutions.PerformanceParticipation.Application.Dtos.Reports;
using DhubSolutions.PerformanceParticipation.Application.Services.Reports.Base;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using DhubSolutions.Reports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DhubSolutions.PerformanceParticipation.Application.Services.Reports
{
    public class ReportTemplateService : ServiceMapper<ReportTemplate>, IReportTemplateService
    {
        private readonly IReportTemplateElementRepository _reportTemplateElementRepository;

        public ReportTemplateService(
            IUnitOfWork unitOfWork,
            ITypeAdapter typeAdapter,
            IReportTemplateRepository repository,
            IReportTemplateElementRepository reportTemplateElementRepository)
            : base(unitOfWork, typeAdapter, repository)
        {
            _reportTemplateElementRepository = reportTemplateElementRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Dto"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override ReportTemplate Add<Dto>(Dto dto)
        {
            switch (dto)
            {
                case ReportTemplateCreationDto reportTemplateCreation:

                    var (userId, reportTemplateDto) = reportTemplateCreation;

                    ReportTemplate reportTemplate = TypeAdapter.Adapt<ReportTemplateDto, ReportTemplate>(reportTemplateDto);

                    reportTemplate.CreatedById = userId;

                    _repository.Add(reportTemplate);

                    return reportTemplate;

                default:
                    throw new InvalidOperationException($"{nameof(dto)} is not ReportTemplateCreationDto");
            }
        }

        public override ReportTemplate Update<Dto>(Dto dto)
        {
            return dto switch
            {
                ReportTemplateUpdateDto reportTemplateUpdateDto => UpdateReportTemplate(reportTemplateUpdateDto),

                _ => throw new InvalidOperationException($"{nameof(dto)} is not ReportTemplateUpdateDto"),
            };
        }

        private ReportTemplate UpdateReportTemplate(ReportTemplateUpdateDto reportTemplateUpdate)
        {
            var (userId, reportTemplateId, reportTemplateDto) = reportTemplateUpdate;

            ReportTemplate reportTemplate = _repository.Get(
                                               predicate: t => t.Id == reportTemplateId,
                                               asNoTracking: true);
            if (reportTemplate == null)
                throw new InvalidOperationException($"The template with Id: {reportTemplateId} was not found");

            reportTemplate.Name = reportTemplateDto.Name;
            reportTemplate.Description = reportTemplateDto.Description;
            reportTemplate.Data = $"{reportTemplateDto.Data}";
            reportTemplate.Metadata = $"{reportTemplateDto.Metadata}";
            reportTemplate.LastModified = DateTime.Now;

            AddOrUpdateReportTemplateElement(reportTemplateDto.Content, (container: null, children: reportTemplate.Content));

            _repository.Update(reportTemplate);

            return reportTemplate;

            #region  local method

            void AddOrUpdateReportTemplateElement(
                IEnumerable<ReportTemplateElementDto> elementDtos,
                (string container, IEnumerable<ReportTemplateElement> children) relationShip)
            {
                var dtos = new Queue<IEnumerable<ReportTemplateElementDto>>();
                var ps = new Queue<(string containerId, IEnumerable<ReportTemplateElement> children)>();

                dtos.Enqueue(elementDtos);
                ps.Enqueue(relationShip);

                while (dtos.Count > 0 && ps.Count > 0)
                {
                    var newDtos = dtos.Dequeue();
                    (var containerId, var children) = ps.Dequeue();

                    foreach (var dto in newDtos)
                    {
                        var element = children.SingleOrDefault(e => string.Equals(e.Code, dto.Code, StringComparison.OrdinalIgnoreCase));
                        if (element == null)
                        {
                            element = new ReportTemplateElement
                            {
                                Name = dto.Name,
                                Description = dto.Description,
                                Type = dto.Type,
                                Code = dto.Code ?? $"{Guid.NewGuid()}",
                                Config = $"{dto.Config}",
                                ContainerId = containerId,
                                ReportTemplateId = reportTemplateId,
                                CreationDate = DateTime.Now,
                                LastModified = DateTime.Now,
                                CreatedById = userId,
                                LastModifiedById = userId,
                            };

                            //Add new ReportTemplateElement()
                            _reportTemplateElementRepository.Add(element);
                        }

                        else
                        {
                            element.Name = dto.Name;
                            element.Description = dto.Description;
                            element.Config = $"{dto.Config}";
                            element.LastModified = DateTime.Now;
                            element.LastModifiedById = userId;

                            //Update ReportTemplateElement()
                            _reportTemplateElementRepository.Update(element);
                        }

                        dtos.Enqueue(dto.Children);
                        ps.Enqueue((containerId: element.Id, children: element.Children));

                    }
                }
            }

            #endregion
        }
    }
}
