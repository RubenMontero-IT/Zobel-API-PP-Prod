using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Application.Dtos.Reports
{
    public class ReportTemplateElementDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JObject Config { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ReportTemplateElementDto> Children { get; set; }

    }
}
