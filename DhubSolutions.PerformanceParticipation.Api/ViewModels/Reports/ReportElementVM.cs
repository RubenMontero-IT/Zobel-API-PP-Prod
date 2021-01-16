using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports
{
    public class ReportElementVM
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JObject Config { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContainerId { get; set; }

        /// <summary>
        /// The children of this element if empty the is a leaf element (pure element)
        /// </summary>
        public IEnumerable<ReportElementVM> Children { get; set; }
    }
}