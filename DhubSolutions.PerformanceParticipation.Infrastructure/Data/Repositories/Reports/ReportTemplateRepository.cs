using DhubSolutions.Core.Domain.Data;
using DhubSolutions.Core.Infrastructure.Data.Repositories;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Context;
using DhubSolutions.Reports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportTemplateRepository : Repository<ReportTemplate>, IReportTemplateRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="unitOfWork"></param>
        public ReportTemplateRepository(PerformanceParticipationDbContext dbContext, IUnitOfWork unitOfWork)
            : base(dbContext, unitOfWork)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportTemplate"></param>
        public override void Add(ReportTemplate reportTemplate)
        {
            reportTemplate.CreationDate = DateTime.Now;
            reportTemplate.LastModified = DateTime.Now;

            foreach (ReportTemplateElement templateElement in reportTemplate.GetAllContent())
            {
                templateElement.CreatedById = reportTemplate.CreatedById;
                templateElement.LastModifiedById = reportTemplate.CreatedById;
                templateElement.ReportTemplateId = reportTemplate.Id;
                templateElement.CreationDate = DateTime.Now;
                templateElement.LastModified = DateTime.Now;

                if (string.IsNullOrEmpty(templateElement.Code))
                    templateElement.Code = $"{Guid.NewGuid()}";
            }

            _dbContext.Set<ReportTemplate>().Add(reportTemplate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public override ReportTemplate Get(
            Expression<Func<ReportTemplate, bool>> predicate,
            bool asNoTracking = true,
            params Expression<Func<ReportTemplate, object>>[] includes)
        {
            ReportTemplate reportTemplate = base.Get(predicate, asNoTracking, includes);

            if (reportTemplate is null)
                return default;

            reportTemplate.Content = GetContent();

            return reportTemplate;

            ICollection<ReportTemplateElement> GetContent()
            {
                IQueryable<ReportTemplateElement> query = _dbContext.Set<ReportTemplateElement>()

                                                .Include(e => e.Children)
                                                .Where(e => e.ReportTemplateId == reportTemplate.Id && e.ContainerId == null);

                if (asNoTracking)
                    query = query.AsNoTracking();

                return query.ToList();
            }

        }
    }
}
