using Newtonsoft.Json;

namespace DhubSolutions.Reports.Domain.Services.Components
{
    [JsonObject]
    public class ReportDataBlock
    {
        [JsonProperty("data")]
        public ReportDataSegment Data { get; set; }

        [JsonProperty("metadata")]
        public ReportDataSegment Metada { get; set; }

    }
}
