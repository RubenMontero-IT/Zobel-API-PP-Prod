using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Common.Domain.Repositories.Admin;
using DhubSolutions.Core.Domain.Adapters;
using DhubSolutions.Reports.Domain.Entities;
using DhubSolutions.Reports.Domain.Services.Base;
using DhubSolutions.Reports.Domain.Services.Components;
using DhubSolutions.Reports.Domain.Services.InstructionProcessors;
using DhubSolutions.Reports.Domain.Services.InstructionProcessors.Factories.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DhubSolutions.Reports.Domain.Services
{
    public class ReportManagerService : IReportManagerService
    {
        private readonly ITypeAdapter _typeAdapter;

        public ReportManagerService(
            ITypeAdapter typeAdapter,
            IInstructionProcessorFactoryProxy instructionProcessorFactoryProxy)
        {
            _typeAdapter = typeAdapter;
            InstructionProcessorFactoryProxy = instructionProcessorFactoryProxy;
        }

        public IInstructionProcessorFactoryProxy InstructionProcessorFactoryProxy { get; }

        public Report CreateReport(
            string name, ReportTemplate template, User user,
            Organization organization, OrganizationRole organizationRole,
            Dictionary<string, dynamic> parameters)
        {
            Report report = _typeAdapter.Adapt<ReportTemplate, Report>(template);

            report.SetCreationOptions(parameters);

            var properties = new (string, object)[]
            {
                ("organization",organization.OrganizationName),
                ("currentDay" ,DateTime.Now)
            };

            SetMetadataValues(report, parameters, properties);

            InstructionProcessorFactoryProxy.AddLocalParameters((nameof(organization), organization));

            FillReportData(report, template, parameters);

            report.CreatedById = user.Id;
            report.Name = name;

            return report;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        /// <param name="parameters"></param>
        /// <param name="properties"></param>
        public void SetMetadataValues(Report report,
            Dictionary<string, dynamic> parameters,
            params (string name, object value)[] properties)
        {
            JObject metaData = JObject.Parse(report.Metadata);

            ProcessJToken(metaData, parameters);

            foreach (var (name, value) in properties)
            {
                metaData[name] = new JValue(value);
            }

            report.Metadata = $"{ metaData}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        /// <param name="template"></param>
        public void FillReportData(Report report, ReportTemplate template, Dictionary<string, dynamic> parameters, params string[] datablocks)
        {
            if (datablocks.Length == 0)
                datablocks = template.DataJObject.Properties().Select(prop => prop.Name).ToArray();

            Task[] readTasks = new Task[datablocks.Length];
            (string propertyName, dynamic @object)[] dataResults = new (string, dynamic)[datablocks.Length];

            int index = 0;
            foreach (JProperty jProperty in template.DataJObject.Properties().Where(prop => datablocks.Contains(prop.Name)))
            {
                JObject dataBlock = JObject.Parse($"{jProperty.Value}");

                dataResults[index].propertyName = jProperty.Name;

                readTasks[index] = InstructionProcessorFactoryProxy
                    .ReadBlockDataSegments(dataBlock, dataResults, index, parameters);

                index++;
            }

            bool allTaskAreCompleted = false;
            try
            {
                Task.WaitAll(readTasks);
                allTaskAreCompleted = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            if (!allTaskAreCompleted)
            {
                var incompleteTasks = readTasks.Where(t => !t.IsCompleted);
                Console.WriteLine(incompleteTasks);
            }

            JObject reportData = string.IsNullOrEmpty(report.Data) ? new JObject() : JObject.Parse(report.Data);
            foreach (var (propertyName, @object) in dataResults)
            {
                reportData[propertyName] = @object;
            }

            report.Data = $"{reportData}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportTemplate"></param>
        /// <param name="parameters"></param>
        /// <param name="expanderValues"></param>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public ReportTemplate GetPosTemplate(ReportTemplate reportTemplate, Dictionary<string, dynamic> parameters, JObject expanderValues, string propertyId)
        {
            ReportTemplate posTemplate = _typeAdapter.Adapt<ReportTemplate, ReportTemplate>(reportTemplate);

            JObject dataBlock = JObject.Parse(posTemplate.Data);

            ProcessModules(
                reportTemplate.Content.Zip(posTemplate.Content, (src, dest) => (src, dest)));

            posTemplate.Data = $"{dataBlock}";

            return posTemplate;

            #region local methods


            void ProcessModules(IEnumerable<(ReportTemplateElement, ReportTemplateElement)> modules)
            {
                foreach (var (source, target) in modules)
                {
                    ProcessSections(source.Children.Zip(target.Children, (src, dest) => (src, dest)));
                }
            }


            void ProcessSections(IEnumerable<(ReportTemplateElement, ReportTemplateElement)> sections)
            {
                foreach (var (source, target) in sections)
                {
                    target.Children = ProcessContentExpander(source.Children.Zip(target.Children, (src, dest) => (src, dest)))
                        .ToList();
                }
            }


            IEnumerable<ReportTemplateElement> ProcessContentExpander(
                IEnumerable<(ReportTemplateElement, ReportTemplateElement)> contentExpanders)
            {
                var expandedPages = new List<ReportTemplateElement>();

                foreach (var (src, dest) in contentExpanders)
                {
                    if (src.Type != "CONTENT_EXPANDER")
                    {
                        JObject config = JObject.Parse(dest.Config);

                        ProcessJToken(config, parameters);

                        dest.Config = $"{config}";

                        expandedPages.Add(dest);
                    }
                    else
                    {
                        string expanderId = $"{src.ConfigJObject["expander"]}";
                        JToken expandedValue = expanderValues[expanderId];

                        List<JObject> jObjects = null;
                        switch (expandedValue)
                        {
                            case JArray array:
                                jObjects = array.Children<JObject>().ToList();
                                break;

                            case JObject jObject:
                                jObjects = new List<JObject> { jObject };
                                break;

                            default:
                                break;
                        }

                        foreach (JObject jObject in jObjects)
                        {
                            var localParameters = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>($"{jObject}");

                            foreach (var keyValuePair in parameters)
                                localParameters.TryAdd(keyValuePair.Key, keyValuePair.Value);

                            var clonedPages = _typeAdapter.Adapt<ICollection<ReportTemplateElement>>(src.Children).ToList();

                            foreach (ReportTemplateElement page in clonedPages)
                            {
                                ProceessPage(page, localParameters);
                            }

                            expandedPages.AddRange(clonedPages);
                        };
                    }
                }

                return expandedPages;
            }

            void ProceessPage(ReportTemplateElement page, Dictionary<string, dynamic> parametersCollection)
            {
                foreach (var element in page.GetAllContent())
                {
                    JObject childConfig = JObject.Parse(element.Config);

                    ProcessJToken(childConfig, parametersCollection);

                    string dataIndex = $"{childConfig["dataIndex"]}";
                    if (string.IsNullOrEmpty(dataIndex) || string.IsNullOrWhiteSpace(dataIndex))
                    {
                        element.Config = $"{childConfig}";
                        continue;
                    }

                    if (childConfig["dataIndex"] is JObject @object)
                    {
                        dataIndex = $"{@object["key"]}";

                        dynamic propertyValue = propertyId;
                        if (propertyId.StartsWith('@'))
                            parametersCollection.TryGetValue(propertyId.Substring(1), out propertyValue);

                        string newDataIndex = $"{dataIndex}.{propertyValue}";

                        childConfig["dataIndex"] = newDataIndex;
                        element.Config = $"{childConfig}";

                        string stringDataSegments = $"{ reportTemplate.DataJObject[dataIndex]}";
                        if (string.IsNullOrEmpty(stringDataSegments) || string.IsNullOrWhiteSpace(stringDataSegments))
                            throw new NullReferenceException($"{dataIndex} data segment not found");

                        JObject dataSegments = JObject.Parse(stringDataSegments);

                        dataSegments.Remove("template");

                        foreach (JProperty property in dataSegments.Properties())
                        {
                            ReportDataSegment dataSegment = JsonConvert.DeserializeObject<ReportDataSegment>($"{ property.Value }");

                            SetParameterValue(dataSegment, parametersCollection);

                            dataSegments[property.Name] = JObject.Parse($"{JsonConvert.SerializeObject(dataSegment)}");
                        }

                        dataBlock[newDataIndex] = JObject.Parse($"{dataSegments}");
                    }
                }
            }


            void SetParameterValue(ReportDataSegment dataSegment, Dictionary<string, dynamic> parametersCollection)
            {
                switch (dataSegment.Type)
                {
                    case InstructionProcessorType.NONE:
                    case InstructionProcessorType.FUNCTION:
                    case InstructionProcessorType.SQL_STATEMENT:
                    case InstructionProcessorType.API:
                        break;

                    case InstructionProcessorType.DATA:

                        JToken jToken = JsonConvert.DeserializeObject<JToken>($"{dataSegment.Value}");
                        ProcessJToken(jToken, parametersCollection);
                        dataSegment.Value = JsonConvert.DeserializeObject<dynamic>($"{jToken}");
                        break;

                    case InstructionProcessorType.METHOD:
                        ProcessParams(dataSegment.Params, parametersCollection);
                        break;

                    default:
                        break;
                }

            }


            void ProcessParams(List<ReportDataParam> reportDataParams, Dictionary<string, dynamic> parametersCollection)
            {
                reportDataParams.ForEach(reportDataParam =>
                {
                    if (reportDataParam.ParamValue.StartsWith('@') &&
                    parametersCollection.TryGetValue(reportDataParam.ParamValue.Substring(1), out var value))
                    {
                        reportDataParam.ParamValue = $"{value}";
                    }
                });
            }

            #endregion

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportTemplate"></param>
        /// <param name="expanderValue"></param>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public bool CanProcessExpanderBlock(ReportTemplate reportTemplate,
            Organization organization,
            Dictionary<string, dynamic> parameters, out JObject expanderValue, out string propertyId)
        {
            expanderValue = null;
            JObject expanderObject = JObject.Parse($"{reportTemplate.MetadataJObject["expander"]}");

            Task[] tasks = new Task[1];

            (string propertyName, dynamic @object)[] dataResults = new (string, dynamic)[1];

            const int index = 0;

            dataResults[index].propertyName = "expander";

            propertyId = $"{expanderObject["propertyId"]}";

            expanderObject.Remove("propertyId");

            InstructionProcessorFactoryProxy
                .AddLocalParameters((nameof(organization), organization));

            tasks[0] = InstructionProcessorFactoryProxy
                .ReadBlockDataSegments(expanderObject, dataResults, index, parameters);


            bool isCompleted;
            try
            {
                Task.WaitAll(tasks);
                isCompleted = true;
            }

            catch (Exception)
            {
                throw;
            }

            if (isCompleted)
            {
                JObject metadataObject = JObject.Parse($"{reportTemplate.MetadataJObject}");

                //exclude expander property from metadata 
                metadataObject.Remove("expander");

                reportTemplate.Metadata = $"{metadataObject}";

                //build expander object
                var (_, @object) = dataResults[index];
                expanderValue = (JObject)@object;
            }

            return isCompleted;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="parametersCollection"></param>
        private void ProcessJToken(JToken token, Dictionary<string, dynamic> parametersCollection)
        {
            ProcessValueRec(token);

            void ProcessValueRec(JToken jToken)
            {
                switch (jToken)
                {
                    case JArray jArray:
                        foreach (JToken item in jArray)
                            ProcessValueRec(item);
                        break;

                    case JObject jObject:
                        foreach (var item in jObject)
                            ProcessValueRec(item.Value);
                        break;

                    case JValue jValue:

                        if (jValue.Value is string str && str.StartsWith('@') &&
                             parametersCollection.TryGetValue(str.Substring(1), out var value))

                            jValue.Value = value;
                        break;
                }
            }
        }

    }
}
