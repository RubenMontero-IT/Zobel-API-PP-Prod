using System.Net;

namespace DhubSolutions.PerformanceParticipation.Api.Errors
{
    public class NotFoundError : ApiError
    {
        public NotFoundError()
            : base(404, $"{HttpStatusCode.NotFound}")
        { }


        public NotFoundError(string message)
            : base(404, $"{HttpStatusCode.NotFound}", message)
        { }
    }
}
