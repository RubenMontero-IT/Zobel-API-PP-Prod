using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DhubSolutions.Common.Application.Services.Admin.Base;
using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Core.Domain.Data;
using DhubSolutions.PerformanceParticipation.Application.Dtos.DataUploader;
using DhubSolutions.PerformanceParticipation.Application.Services.DataUploader.Base;
using DhubSolutions.PerformanceParticipation.Api.Controllers.Base;
using DhubSolutions.PerformanceParticipation.Api.Errors;

namespace DhubSolutions.PerformanceParticipation.Api.Controllers
{
    [Route("api/v{version:apiVersion}/{orgRoleId}/dataUploader")]
    [ApiController]
    [ApiVersion("1")]

    public class DataUploaderController : BaseController
    {
        private readonly IDataUploaderService _dataUploaderService;
        private readonly IOrganizationRoleService _organizationRoleService;

        public DataUploaderController(
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IDataUploaderService dataUploaderService,
            IOrganizationRoleService organizationRoleService) : base(unitOfWork, userManager)
        {
            _dataUploaderService = dataUploaderService;
            _organizationRoleService = organizationRoleService;
        }


        [HttpPost("upload", Name = "UploadJson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerError))]
        public IActionResult UploadJSON([FromRoute] string orgRoleId, [FromBody] JsonInputDto input)
        {
            if (string.IsNullOrWhiteSpace(orgRoleId) || string.IsNullOrEmpty(orgRoleId))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new BadRequestError($"'{nameof(orgRoleId)}' cannot be null or whitespace"));

            if (!ModelState.IsValid)
                return BadRequest("Invalid Model");

            OrganizationRole organizationRole = _organizationRoleService.Get<OrganizationRole>(
                                                               orgRole => orgRole.Id == orgRoleId,
                                                               asNoTracking: true,
                                                               orgRole => orgRole.Organization);
            if (organizationRole == null)
                return StatusCode(StatusCodes.Status404NotFound, new NotFoundError($"organizationRole not found"));


            try
            {
                _dataUploaderService.Insert(input.PerfPartcipationDetails);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new InternalServerError(ex.Message));
            }

        }
    }
}