using System;
using System.Collections.Generic;
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
    [Route("api/v{version:apiVersion}/{orgRoleId}/templates")]
    [ApiController]
    [ApiVersion("1")]
    public class ReportTemplateController : BaseController
    {
        private readonly IOrganizationRoleService organizationRoleService;
        private readonly IReportTemplateService reportTemplateService;

        public ReportTemplateController(
            ITypeAdapter typeAdapter,
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IOrganizationRoleService organizationRoleService,
            IReportTemplateService reportTemplateService)
            : base(typeAdapter, unitOfWork, userManager)
        {
            this.organizationRoleService = organizationRoleService;
            this.reportTemplateService = reportTemplateService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <returns></returns>
        // GET: api/<ReportTemplateController>
        [HttpGet(Name = "Get all templates")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<ShortReportTemplateVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult Get([FromRoute] string orgRoleId)
        {
            if (string.IsNullOrEmpty(orgRoleId) || string.IsNullOrWhiteSpace(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest, new BadRequestError("organizationRoleId Parameter cant be null"));


            OrganizationRole organizationRole = organizationRoleService.Get<OrganizationRole>(
                                                        orgRole => orgRole.Id == orgRoleId,
                                                        asNoTracking: true);


            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"OrganizationRole not found"));

            var reportTemplates = reportTemplateService.GetAll<ShortReportTemplateVM>(
                                                                            filter: null,
                                                                            asNoTracking: true,
                                                                            rt => rt.CreatedBy);
            return Ok(reportTemplates);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        // GET api/<ReportTemplateController>/5
        [HttpGet("{templateId}", Name = "Get template")]
        public async Task<IActionResult> Get([FromRoute] string orgRoleId, [FromRoute] string templateId)
        {
            if (string.IsNullOrEmpty(templateId) || string.IsNullOrWhiteSpace(templateId))
                return StatusCode(StatusCodes.Status400BadRequest,
                                 new BadRequestError($"{nameof(templateId)}  cannot be null or empty"));

            if (string.IsNullOrEmpty(orgRoleId) || string.IsNullOrWhiteSpace(orgRoleId))
                StatusCode(StatusCodes.Status400BadRequest,
                                 new BadRequestError($"{nameof(orgRoleId)}  cannot be null or empty"));

            OrganizationRole organizationRole = organizationRoleService.Get<OrganizationRole>(
                                                        orgRole => orgRole.Id == orgRoleId, asNoTracking: true);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("OrganizationRole not found"));

            User user = await GetCurrentUser();
            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("current User not found"));

            ReportTemplateVM reportTemplate = reportTemplateService.Get<ReportTemplateVM>(
                                                        t => t.Id == templateId, asNoTracking: true);
            if (reportTemplate == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("template not found"));

            return StatusCode(StatusCodes.Status200OK, reportTemplate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <param name="reportTemplateVM"></param>
        /// <returns></returns>
        // POST api/<ReportTemplateController>
        [HttpPost(Name = "create template")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Post([FromRoute] string orgRoleId, [FromBody] ReportTemplateVM reportTemplateVM)
        {
            if (string.IsNullOrWhiteSpace(orgRoleId) || string.IsNullOrEmpty(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError($"'{nameof(orgRoleId)}' cannot be null or whitespace"));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            OrganizationRole organizationRole = organizationRoleService
                                               .Get<OrganizationRole>(orgRole => orgRole.Id == orgRoleId, asNoTracking: true);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"OrganizationRole not found"));

            User user = await GetCurrentUser();
            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound,
                    new NotFoundError("Current user not found"));

            ReportTemplateDto reportTemplateDto = _typeAdapter.Adapt<ReportTemplateVM, ReportTemplateDto>(reportTemplateVM);

            var reportTemplateCreationDto = new ReportTemplateCreationDto
            {
                UserId = user.Id,
                ReportTemplateDto = reportTemplateDto
            };

            ReportTemplate reportTemplate = reportTemplateService.Add(reportTemplateCreationDto);

            _unitOfWork.SaveChanges();

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new
                {
                    version = $"{HttpContext.GetRequestedApiVersion()}",
                    orgRoleId = organizationRole.Id,
                    templateId = reportTemplate.Id
                },
                value: reportTemplate.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrgRoleId"></param>
        /// <param name="templateId"></param>
        /// <param name="reportTemplateVM"></param>
        /// <returns></returns>
        // PUT api/<ReportTemplateController>/5
        [HttpPut("{templateId}", Name = "update template")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundError))]
        public async Task<IActionResult> Put([FromRoute] string OrgRoleId, [FromRoute] string templateId, [FromBody] ReportTemplateVM reportTemplateVM)
        {
            if (string.IsNullOrEmpty(OrgRoleId) || string.IsNullOrWhiteSpace(OrgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                  new BadRequestError($"{nameof(OrgRoleId)} Parameter cant be null"));

            if (string.IsNullOrEmpty(templateId) || string.IsNullOrWhiteSpace(templateId))
                return StatusCode(StatusCodes.Status400BadRequest,
                  new BadRequestError($"{nameof(templateId)} Parameter cant be null"));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            OrganizationRole organizationRole = organizationRoleService
                                               .Get<OrganizationRole>(orgRole => orgRole.Id == OrgRoleId);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound,
                                  new NotFoundError($"OrganizationRole not found"));

            User user = await GetCurrentUser();
            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("current User not found"));

            ReportTemplateDto reportTemplateDto = _typeAdapter.Adapt<ReportTemplateVM, ReportTemplateDto>(reportTemplateVM);

            var reportTemplateUpdateDto = new ReportTemplateUpdateDto
            {
                UserId = user.Id,
                ReportTemplateId = templateId,
                ReportTemplatedDto = reportTemplateDto
            };

            try
            {
                reportTemplateService.Update(reportTemplateUpdateDto);

                if (_unitOfWork.SaveChanges() < 0)
                    return StatusCode(StatusCodes.Status400BadRequest,
                                      new BadRequestError("Error when trying to update a template"));

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  new BadRequestError(ex.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgRoleId"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        // DELETE api/<ReportTemplateController>/5
        [HttpDelete("{templateId}", Name = "delete template")]
        public IActionResult Delete([FromRoute] string orgRoleId, [FromRoute] string templateId)
        {
            if (string.IsNullOrEmpty(orgRoleId) || string.IsNullOrWhiteSpace(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                  new BadRequestError($"{nameof(orgRoleId)}  cannot be null or empty"));

            if (string.IsNullOrEmpty(templateId) || string.IsNullOrWhiteSpace(templateId))
                return StatusCode(StatusCodes.Status400BadRequest,
                  new BadRequestError($"{nameof(templateId)}  cannot be null or empty"));

            OrganizationRole organizationRole = organizationRoleService.Get<OrganizationRole>(
                                                      orgRole => orgRole.Id == orgRoleId, asNoTracking: true);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("OrganizationRole not found"));

            ReportTemplate reportTemplate = reportTemplateService.Get<ReportTemplate>(
                                                      t => t.Id == templateId, asNoTracking: true);
            if (reportTemplate == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError("template not found"));

            reportTemplateService.Remove(reportTemplate);

            _unitOfWork.SaveChanges();

            return Ok();

        }
    }
}


