﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Application.Dtos.Reports
{
    public class ReportTemplateDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A Description of the Template
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A Name for the Template
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The Metadata of this template
        /// </summary>
        public JObject Metadata { get; set; }

        /// <summary>
        /// Gets or sets the data property
        /// </summary>
        public JObject Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ReportTemplateElementDto> Content { get; set; }

    }
}
