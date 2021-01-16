using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DhubSolutions.Common.Application.Services.Admin.Base;
using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Core.Domain.Adapters;
using DhubSolutions.Core.Domain.Data;
using DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports;
using DhubSolutions.PerformanceParticipation.Application.Dtos.Reports;
using DhubSolutions.PerformanceParticipation.Application.Services.Reports.Base;
using DhubSolutions.Reports.Domain.Entities;
using DhubSolutions.PerformanceParticipation.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DhubSolutions.PerformanceParticipation.Api.Errors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DhubSolutions.PerformanceParticipation.Api.Controllers
{

    [Route("api/v{version:apiVersion}/{orgRoleId}/reports")]
    [ApiController]
    [ApiVersion("1")]
    public class ReportController : BaseController
    {
        private readonly IOrganizationService organizationService;
        private readonly IOrganizationRoleService organizationRoleService;
        private readonly IReportTemplateService reportTemplateService;
        private readonly IReportService reportService;

        public ReportController(
            ITypeAdapter typeAdapter,
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IOrganizationService organizationService,
            IOrganizationRoleService organizationRoleService,
            IReportTemplateService reportTemplateService,
            IReportService reportService)
            : base(typeAdapter, unitOfWork, userManager)
        {
            this.organizationService = organizationService;
            this.organizationRoleService = organizationRoleService;
            this.reportTemplateService = reportTemplateService;
            this.reportService = reportService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/<ReportController>
        [HttpGet(Name = "Get all reports")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<ShortReportVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult Get([FromRoute] string orgRoleId)
        {
            if (string.IsNullOrWhiteSpace(orgRoleId) || string.IsNullOrEmpty(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError($"'{nameof(orgRoleId)}' cannot be null or whitespace"));

            OrganizationRole organizationRole = organizationRoleService.Get<OrganizationRole>(
                                                                orgRole => orgRole.Id == orgRoleId,
                                                                asNoTracking: true,
                                                                orgRole => orgRole.Organization);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"organizationRole not found"));

            IEnumerable<Report> reports = reportService.GetAll<Report>(null,
                                                asNoTracking: true,
                                                report => report.CreatedBy);
            //.Where(report =>
            //         $"{report.MetadataJObject["organization"]}" == organizationRole.Organization.OrganizationName);

            return Ok(_typeAdapter.Adapt<IEnumerable<ShortReportVM>>(reports));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        // GET api/<ReportController>/5
        [HttpGet("{reportId}", Name = "Get report")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReportVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult Get([FromRoute] string orgRoleId, [FromRoute] string reportId)
        {
            if (string.IsNullOrWhiteSpace(orgRoleId) || string.IsNullOrEmpty(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                                new BadRequestError($"'{nameof(orgRoleId)}' cannot be null or whitespace"));

            if (string.IsNullOrWhiteSpace(reportId) || string.IsNullOrEmpty(reportId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError($"'{nameof(reportId)}' cannot be null or whitespace"));

            OrganizationRole organizationRole = organizationRoleService
                                              .Get<OrganizationRole>(orgRole => orgRole.Id == orgRoleId, asNoTracking: true);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"organizationRole not found"));

            ReportVM reportVM = reportService.Get<ReportVM>(
                                                report => report.Id == reportId,
                                                asNoTracking: true,
                                                r => r.CreatedBy);
            if (reportVM == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"report not found"));

            return StatusCode(StatusCodes.Status200OK, reportVM);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <param name="vm"></param>
        /// <returns></returns>
        // POST api/<ReportController>
        [HttpPost(Name = "Create report")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShortReportVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Post([FromRoute] string orgRoleId, [FromBody] ReportCreationVM vm)
        {
            if (string.IsNullOrWhiteSpace(orgRoleId) || string.IsNullOrEmpty(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError($"'{nameof(orgRoleId)}' cannot be null or whitespace"));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (name, reportTemplateId, organizationId, parameters) = vm;

            OrganizationRole organizationRole = organizationRoleService
                                                .Get<OrganizationRole>(orgRole => orgRole.Id == orgRoleId, asNoTracking: true);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"OrganizationRole not found"));

            Organization organization = organizationService
                                                .Get<Organization>(org => org.Id == organizationId, asNoTracking: true);
            if (organization == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"Organization not found"));

            ReportTemplate reportTemplate = reportTemplateService.Get<ReportTemplate>(
                                                            rt => rt.Id == reportTemplateId,
                                                            asNoTracking: true);

            if (reportTemplate == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("ReportTemplate not found"));

            User user = await GetCurrentUser();
            if (user is null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("Current user not found"));

            var reportCreationDto = new ReportCreationDto()
            {
                ReportName = name,
                ReportTemplate = reportTemplate,
                Organization = organization,
                OrganizationRole = organizationRole,
                User = user,
                Parameters = parameters
            };

            Report report = reportService.Add(reportCreationDto);
            if (_unitOfWork.SaveChanges() < 0)
                return BadRequest("Error when trying to insert a report");

            ShortReportVM shortReportVM = _typeAdapter.Adapt<Report, ShortReportVM>(report);

            shortReportVM.CreatedBy = user.UserName;

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new
                {
                    version = $"{HttpContext.GetRequestedApiVersion()}",
                    orgRoleId = organizationRole.Id,
                    reportId = report.Id
                },
                value: shortReportVM);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <param name="reportId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT api/<ReportController>/5
        [HttpPut("{reportId}/content", Name = "Update report content")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundError))]
        public async Task<IActionResult> Put([FromRoute] string orgRoleId, [FromRoute] string reportId, [FromBody] ReportContentVM model)
        {
            if (string.IsNullOrEmpty(orgRoleId) || string.IsNullOrWhiteSpace(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError($"'{nameof(orgRoleId)}' cannot be null or whitespace"));

            if (string.IsNullOrEmpty(reportId) || string.IsNullOrWhiteSpace(reportId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError("reportId Parameter cant be null"));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            OrganizationRole organizationRole = organizationRoleService
                                                .Get<OrganizationRole>(orgRole => orgRole.Id == orgRoleId);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"OrganizationRole not found"));

            User user = await GetCurrentUser();

            ReportContentDto reportUpdated = _typeAdapter.Adapt<ReportContentVM, ReportContentDto>(model);
            reportUpdated.ReportId = reportId;
            reportUpdated.UserId = user.Id;

            try
            {
                reportService.Update(reportUpdated);

                if (_unitOfWork.SaveChanges() < 0)
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new BadRequestError("Error when trying to update a report content"));

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (NullReferenceException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerError(e.Message));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new BadRequestError(e.Message));
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <param name="reportId"></param>
        /// <returns></returns>
        // DELETE api/<ReportController>/5
        [HttpDelete("{reportId}", Name = "Delete report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerError))]
        public IActionResult RemoveReport([FromRoute] string orgRoleId, [FromRoute] string reportId)
        {
            if (string.IsNullOrEmpty(orgRoleId) || string.IsNullOrWhiteSpace(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError("organizationRoleId Parameter cant be null"));

            if (string.IsNullOrEmpty(reportId) || string.IsNullOrWhiteSpace(reportId))
                return StatusCode(StatusCodes.Status400BadRequest,
                   new BadRequestError("reportId Parameter can't be null"));

            OrganizationRole organizationRole = organizationRoleService
                                       .Get<OrganizationRole>(orgRole => orgRole.Id == orgRoleId,
                                                              asNoTracking: true);

            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound,
                  new BadRequestError($"OrganizationRole not found"));

            try
            {
                Report report = reportService.Get<Report>(r => r.Id == reportId, asNoTracking: true);
                if (report == null)
                    return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"report not found"));

                reportService.Remove(report);

                reportService.UnitOfWork.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new BadRequestError(ex.Message));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerError(ex.Message));
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <param name="reportIds"></param>
        /// <returns></returns>
        [HttpDelete(Name = "Delete reports")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerError))]
        public IActionResult RemoveReport([FromRoute] string orgRoleId, [FromBody] string[] reportIds)
        {
            if (string.IsNullOrEmpty(orgRoleId) || string.IsNullOrWhiteSpace(orgRoleId))
                return BadRequest("organizationRoleId Parameter cant be null");

            OrganizationRole organizationRole = organizationRoleService
                                       .Get<OrganizationRole>(orgRole => orgRole.Id == orgRoleId, asNoTracking: true);

            if (organizationRole == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError($"OrganizationRole not found"));

            try
            {
                IEnumerable<Report> reports = reportService.GetAll<Report>(
                                        report => reportIds.Contains(report.Id), asNoTracking: true);

                reportService.RemoveRange(reports);

                _unitOfWork.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new BadRequestError(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerError(ex.Message));
            }

        }
    }
}
