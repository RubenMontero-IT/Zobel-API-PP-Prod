namespace DhubSolutions.PerformanceParticipation.Application.Dtos.Reports
{
    public class ReportTemplateCreationDto
    {
        public string UserId { get; set; }
        public ReportTemplateDto ReportTemplateDto { get; set; }

        public void Deconstruct(out string userId, out ReportTemplateDto reportTemplateDto)
        {
            userId = UserId;
            reportTemplateDto = ReportTemplateDto;
        }
    }
}
