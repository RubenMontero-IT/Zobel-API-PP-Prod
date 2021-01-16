using DhubSolutions.Reports.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DhubSolutions.Reports.Domain.Entities
{
    public class ReportElement : BaseReportElement
    {
        public ReportElement() : base()
        {
            Children = new List<ReportElement>();
        }

        /// <summary>
        /// The Id of the report witch is parent of this container
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// The Navigation Prop of the report that is parent of this element
        /// </summary>
        public Report Report { get; set; }

        /// <summary>
        /// The id of template element from wich this report element was created
        /// </summary>
        public string ReportTemplateElementId { get; set; }

        /// <summary>
        /// The template element from wich this report element was created
        /// </summary>
        public ReportTemplateElement ReportTemplateElement { get; set; }

        /// <summary>
        /// The Id of the parent container for this element
        /// </summary>
        public string ContainerId { get; set; }

        /// <summary>
        /// The Container of this element, If null then is a root element and the parent is the this.Report
        /// </summary>
        public ReportElement Container { get; set; }

        /// <summary>
        /// The children of this element if empty the is a leaf element (pure element)
        /// </summary>
        public ICollection<ReportElement> Children { get; set; }

        /// <summary>
        /// The permissions of the active user
        /// <Note>Not Mapped To DB</Note>
        /// </summary>
        [NotMapped]
        public IEnumerable<string> ActivePermissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public bool UpdateUpReferences(string reportId, string containerId)
        {
            //The id of this reportElement for some reason its not been set
            if (string.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id))
                return false;

            ReportId = reportId;
            ContainerId = containerId;

            //Checks if all the children where updated ok
            bool result = true;

            foreach (var child in Children)
                result &= child.UpdateUpReferences(reportId, Id);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReportElement> GetAllContent()
        {
            foreach (var element in Children)
            {
                yield return element;

                foreach (var child in element.GetAllContent())
                {
                    yield return child;
                }
            }
        }

    }
}
