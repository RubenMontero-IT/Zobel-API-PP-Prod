using System.Net;

namespace DhubSolutions.PerformanceParticipation.Api.Errors
{
    public class BadRequestError : ApiError
    {
        public BadRequestError() : base(400, $"{HttpStatusCode.BadRequest }")
        {
        }

        public BadRequestError(string message) : base(400, $"{ HttpStatusCode.BadRequest}", message)
        {
        }
    }
}
