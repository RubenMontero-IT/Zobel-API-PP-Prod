using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace DhubSolutions.PerformanceParticipation.Api.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveVersionParameterFilter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameterVersion = operation?.Parameters?.SingleOrDefault(param => param.Name == "version");
            operation?.Parameters?.Remove(parameterVersion);
        }
    }
}
