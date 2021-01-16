using System.Threading.Tasks;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DhubSolutions.PerformanceParticipation.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    [ApiVersion("1")]
    public class TestQueriesController : ControllerBase
    {
        private readonly IReportDataRepository _reportDataRepository;
        public TestQueriesController(IReportDataRepository reportDataRepository) : base()
        {
            _reportDataRepository = reportDataRepository;
        }


        [HttpGet("organizations", Name = "GetOrganizations")]
        public async Task<string> GetOrganizations()
        {
            var a = await _reportDataRepository.GetOrganizations();
            return $"{JToken.Parse(a)}";
        }


        [HttpGet("PerformanceDetails", Name = "GetPerformanceDetails")]
        public async Task<string> GetPerformanceDetails(int? initialYear, int? endYear)
        {
            var a = await _reportDataRepository.GetPerformanceDetails(initialYear, endYear);
            return $"{JToken.Parse(a)}";
        }


        [HttpGet("NormalizationDetails", Name = "GetNormalizationDetails")]
        public async Task<string> GetNormalizationDetails(int? initialYear, int? endYear, string mainCategory, string accountLevelID)
        {
            var a = await _reportDataRepository.GetNormalizationDetails(initialYear, endYear, mainCategory, accountLevelID);
            return $"{JToken.Parse(a)}";
        }

    }
}