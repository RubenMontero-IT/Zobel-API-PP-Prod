using DhubSolutions.Reports.Domain.Entities.Base;
using System.Collections.Generic;


namespace DhubSolutions.Reports.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportTemplate : BaseReport
    {
        public ReportTemplate() : base()
        {
            Content = new List<ReportTemplateElement>();
        }

        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the content of this report.
        /// </summary>
        /// <value>The components.</value>
        public ICollection<ReportTemplateElement> Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReportTemplateElement> GetAllContent()
        {
            foreach (var element in Content)
            {
                foreach (var child in element.GetAllContent())
                {
                    yield return child;
                }
            }
        }
    }
}
