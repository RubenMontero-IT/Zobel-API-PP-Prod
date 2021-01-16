using System;

namespace DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports
{
    public class ShortReportTemplateVM
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastModified { get; set; }
    }
}
