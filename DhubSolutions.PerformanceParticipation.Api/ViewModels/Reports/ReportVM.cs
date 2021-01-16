using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports
{
    public class ReportVM
    {
        public string Id { get; set; }

        /// <summary>
        /// A Name for the Report
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A Description of the Report
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Id of the creator
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// The Metadata of this report
        /// </summary>
        public JObject Metadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JObject Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ReportElementVM> Content { get; set; }




    }
}
