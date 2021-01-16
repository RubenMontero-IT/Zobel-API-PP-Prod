using DhubSolutions.Core.Application.Services;
using DhubSolutions.Core.Domain.Adapters;
using DhubSolutions.Core.Domain.Data;
using DhubSolutions.PerformanceParticipation.Application.Dtos.Reports;
using DhubSolutions.PerformanceParticipation.Application.Services.Reports.Base;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using DhubSolutions.Reports.Domain.Entities;
using DhubSolutions.Reports.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DhubSolutions.PerformanceParticipation.Application.Services.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportService : ServiceMapper<Report>, IReportService
    {
        private readonly IReportElementRepository _reportElementRepository;
        private readonly IReportManagerService _reportManagerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="typeAdapter"></param>
        /// <param name="repository"></param>
        public ReportService(
            IUnitOfWork unitOfWork,
            ITypeAdapter typeAdapter,
            IReportRepository repository,
            IReportElementRepository reportElementRepository,
            IReportManagerService reportManagerService)
            : base(unitOfWork, typeAdapter, repository)
        {
            _reportElementRepository = reportElementRepository;
            _reportManagerService = reportManagerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Dto"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Report Add<Dto>(Dto dto)
        {
            switch (dto)
            {
                case ReportCreationDto reportCreationDto:

                    var (name, template, organization, orgRole, user, parameters) = reportCreationDto;

                    Report report = _reportManagerService.CreateReport(
                                                        name: name,
                                                        template: template,
                                                        user: user,
                                                        organization: organization,
                                                        organizationRole: orgRole,
                                                        parameters: parameters);
                    _repository.Add(report);

                    return report;

                default:
                    throw new InvalidOperationException($"{nameof(dto)} is not ReportCreationDto");
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Dto"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Report Update<Dto>(Dto dto)
        {
            return dto switch
            {
                ReportContentDto reportContentDto => UpdateReportContent(reportContentDto),
               
                _ => throw new InvalidOperationException($"{nameof(dto)} is not {nameof(ReportContentDto)}"),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        private Report UpdateReportContent(ReportContentDto dto)
        {
            Report report = _repository.Get(r => r.Id == dto.ReportId, asNoTracking: true);
            if (report == null)
                throw new InvalidOperationException($"{nameof(Report)} not found");

            report.Name = dto.Name ?? report.Name;

            report.LastModified = DateTime.Now;

            // no update report Content
            report.Content.Clear();

            _repository.Update(report);

            if (dto.Removed.Count() != 0)
                RemoveReportElements(dto.Removed);

            if (dto.Added.Count() != 0)
                AddReportElements(dto.Added);

            if (dto.Updated.Count != 0)
                UpdateReportElements(dto.Updated);

            return report;

            #region local methods

            void RemoveReportElements(IEnumerable<string> reportElementIds)
            {
                IEnumerable<ReportElement> reportElements = _reportElementRepository.GetAll(
                        reportElement => reportElementIds.Contains(reportElement.Id), asNoTracking: true);

                if (reportElements.Count() == 0)
                    throw new InvalidOperationException("No reportElements found with the given ids");

                _reportElementRepository.RemoveRange(reportElements);


            }

            void AddReportElements(IEnumerable<ReportElementDto> reportElements)
            {
                foreach (ReportElementDto reportElementDto in reportElements)
                {
                    if (!reportElementDto.UpdateUpReferences(dto.ReportId, reportElementDto.ContainerId))
                        throw new InvalidOperationException(nameof(reportElementDto.UpdateUpReferences));

                    foreach (var child in reportElementDto.GetAllContent())
                    {
                        //Add new reportElement
                        ReportElement reportElement = TypeAdapter.Adapt<ReportElementDto, ReportElement>(child);
                        reportElement.CreatedById = dto.UserId;
                        reportElement.LastModifiedById = dto.UserId;
                        reportElement.CreationDate = DateTime.Now;
                        reportElement.LastModified = DateTime.Now;

                        _reportElementRepository.Add(reportElement);
                    }
                }
            }

            void UpdateReportElements(IEnumerable<ReportElementDto> reportElements)
            {
                foreach (ReportElementDto reportElementDto in reportElements)
                {
                    if (!reportElementDto.UpdateUpReferences(dto.ReportId, reportElementDto.ContainerId))
                        throw new InvalidOperationException(nameof(reportElementDto.UpdateUpReferences));

                    ReportElement reportElement = _reportElementRepository.Get(re => re.Id == reportElementDto.Id, asNoTracking: true);
                    if (reportElement == null)
                        throw new InvalidOperationException($"{nameof(reportElement)} with id {reportElementDto.Id} not found");

                    reportElement = TypeAdapter.Adapt(reportElementDto, reportElement);
                    reportElement.LastModifiedById = dto.UserId;
                    reportElement.LastModified = DateTime.Now;

                    _reportElementRepository.Update(reportElement);
                }
            }

            #endregion
        }
    }
}
