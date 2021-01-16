using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DhubSolutions.Reports.Domain.Services.Components
{
    [JsonObject]
    public class ReportDataParam
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReportParamType ParamType { get; set; }

        [JsonProperty("value")]
        public string ParamValue { get; set; }
    }
}