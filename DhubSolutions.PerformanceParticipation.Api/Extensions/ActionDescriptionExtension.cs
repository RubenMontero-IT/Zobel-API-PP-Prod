using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;
using System.Linq;

namespace DhubSolutions.PerformanceParticipation.Api.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    internal static class ActionDescriptorExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public static ApiVersionModel GetApiVersion(this ActionDescriptor actionDescriptor)
        {
            return (ApiVersionModel)actionDescriptor?.Properties
                .FirstOrDefault(w => ((Type)w.Key).Equals(typeof(ApiVersionModel))).Value;
        }
    }
}
