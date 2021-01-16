using DhubSolutions.Reports.Domain.Entities.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DhubSolutions.Reports.Domain.Entities
{
    public class Report : BaseReport
    {
        public Report() : base()
        {
            Content = new List<ReportElement>();

        }

        /// <summary>
        /// 
        /// </summary>
        public string CreationOptions { get; set; }

        /// <summary>
        /// The id of Template from wich this report was created
        /// </summary>
        public string ReportTemplateId { get; set; }

        /// <summary>
        /// The template from wich this report was created
        /// </summary>
        public ReportTemplate ReportTemplate { get; set; }

        /// <summary>
        /// Gets or sets the content of this report.
        /// </summary>
        /// <value>The components.</value>
        public ICollection<ReportElement> Content { get; set; }

        /// <summary>
        /// The permissions of the active user
        /// <Note>Not Mapped To DB</Note>
        /// </summary>
        [NotMapped]
        public IEnumerable<string> ActivePermissions { get; set; }

        /// <summary>
        /// Updates the references of each element to its parent
        /// </summary>
        /// <returns>True if all elements where updated ok, False if something whent wrong</returns>
        public bool UpdateUpReferences()
        {
            bool result = true;
            //The id of this report for some reason its not been set
            if (string.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id))
                return false;

            foreach (var child in Content)
            {
                child.ReportId = Id;
                result &= child.UpdateUpReferences(Id, null);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creationOptions"></param>
        public void SetCreationOptions(Dictionary<string, dynamic> creationOptions)
        {
            CreationOptions = JsonConvert.SerializeObject(creationOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> GetCreationOptions()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(CreationOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReportElement> GetAllContent()
        {
            foreach (var element in Content)
            {
                yield return element;
                foreach (var child in element.GetAllContent())
                {
                    yield return child;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual JObject GetAccesibleData()
        {
            JObject data = new JObject();

            foreach (ReportElement reportElement in GetAllContent())
            {
                if (reportElement.Config is null)
                    continue;

                string dataIndex = $"{reportElement.ConfigJObject["dataIndex"]}";
                if (string.IsNullOrEmpty(dataIndex) || string.IsNullOrWhiteSpace(dataIndex))
                    continue;

                data[dataIndex] = DataJObject[dataIndex];
            }

            return data;
        }


    }
}
