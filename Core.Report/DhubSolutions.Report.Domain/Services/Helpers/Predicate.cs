using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Services.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public delegate bool Predicate<in T>(T t, params object[] parameters) where T : IAssignableResource;
}
