using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Core.Domain.Adapters;
using DhubSolutions.Core.Domain.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DhubSolutions.PerformanceParticipation.Api.Controllers.Base
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ITypeAdapter _typeAdapter;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly UserManager<User> _userManager;

        protected BaseController(ITypeAdapter typeAdapter, IUnitOfWork unitOfWork, UserManager<User> userManager)
            : this(unitOfWork, userManager)
        {
            _typeAdapter = typeAdapter;
        }

        protected BaseController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        protected async Task<User> GetCurrentUser()
        {
            List<Claim> claims = new List<Claim>(GetCurrentUserClaims());
            string currentUserId = claims.Find(r => r.Type == "UserId").Value;
            return await _userManager.FindByIdAsync(currentUserId);
        }

        protected IEnumerable<Claim> GetCurrentUserClaims()
        {
            return HttpContext.User.Claims;
        }
    }
}