﻿using System.Net;

namespace DhubSolutions.PerformanceParticipation.Api.Errors
{
    public class InternalServerError : ApiError
    {
        public InternalServerError()
            : base(500, $"{ HttpStatusCode.InternalServerError}")
        {
        }


        public InternalServerError(string message)
            : base(500, $"{HttpStatusCode.InternalServerError}", message)
        {
        }
    }
}
