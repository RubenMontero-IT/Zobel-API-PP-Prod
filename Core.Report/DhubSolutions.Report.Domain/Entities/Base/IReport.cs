using DhubSolutions.Reports.Domain.Entities.Base.Permissions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DhubSolutions.Reports.Domain.Entities.Base
{
    public interface IReport : IBaseReport
    {
        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportElement> Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IReportTemplate ReportTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ReportTemplateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportPermission> ReportPermissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        JObject GetAccesibleData();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IReportElement> GetAllContent();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<string, dynamic> GetCreationOptions();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creationOptions"></param>
        void SetCreationOptions(Dictionary<string, dynamic> creationOptions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportPermissions"></param>
        void SetReportPermissions(params IReportPermission[] reportPermissions);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool UpdateUpReferences();
    }
}