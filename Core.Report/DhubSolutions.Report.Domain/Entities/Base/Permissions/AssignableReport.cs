using DhubSolutions.Common.Domain.Entities.Base;
using System;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AssignableReport : AssignableResource, IAssignableReport
    {
        /// <summary>
        /// 
        /// </summary>
        protected AssignableReport() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Report Report { get; set; }

    }
}
