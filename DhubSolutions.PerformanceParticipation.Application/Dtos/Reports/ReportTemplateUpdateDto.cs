namespace DhubSolutions.PerformanceParticipation.Application.Dtos.Reports
{
    public class ReportTemplateUpdateDto
    {
        public string ReportTemplateId { get; set; }

        public string UserId { get; set; }

        public ReportTemplateDto ReportTemplatedDto { get; set; }

        public void Deconstruct(out string userId, out string reportTemplateId, out ReportTemplateDto reportTemplateDto)
        {
            userId = UserId;
            reportTemplateId = ReportTemplateId;
            reportTemplateDto = ReportTemplatedDto;
        }
    }
}
