using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace DhubSolutions.PerformanceParticipation.Api.Filters
{
    public class SetVersionInPathFilter : IDocumentFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths
                                  .ToDictionary(path => path.Key.Replace("v{version}", swaggerDoc.Info.Version),
                                                path => path.Value);

            swaggerDoc.Paths.Clear();
            foreach (var (version, path) in paths)
                swaggerDoc.Paths.Add(version, path);

        }
    }
}
