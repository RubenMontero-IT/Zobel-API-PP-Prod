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
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="unitOfWork"></param>
        public ReportRepository(PerformanceParticipationDbContext dbContext, IUnitOfWork unitOfWork)
            : base(dbContext, unitOfWork)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public override Report Get(Expression<Func<Report, bool>> predicate, bool asNoTracking = true, params Expression<Func<Report, object>>[] includes)
        {
            Report report = base.Get(predicate, asNoTracking, includes);

            if (report is null)
                return default;

            report.Content = GetContent();

            return report;

            ICollection<ReportElement> GetContent()
            {
                IQueryable<ReportElement> queryable = _dbContext.Set<ReportElement>()
                                            .Include(e => e.CreatedBy)
                                            .Include(e => e.LastModifiedBy)
                                            .Include(e => e.Children)
                                            .Where(e => e.ReportId == report.Id && e.ContainerId == null);

                if (asNoTracking)
                    queryable = queryable.AsNoTracking();

                return queryable.ToList();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(Report report)
        {
            if (string.IsNullOrEmpty(report.Id) || string.IsNullOrWhiteSpace(report.Id))
                throw new ArgumentNullException(nameof(report.Id));

            //Patch because he tries to insert this navigation prop as a new entity
            //therefore this results in a duplicate key insertion error 
            report.ReportTemplate = null;

            foreach (var element in report.GetAllContent())
            {
                element.ReportTemplateElement = null;
                element.CreatedById = report.CreatedById;
                element.LastModifiedById = report.CreatedById;
            }
            _dbContext.Set<Report>().Add(report);
        }
    }
}
