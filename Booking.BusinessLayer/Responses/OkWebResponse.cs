using System;
using System.Net;

namespace Booking.BusinessLayer.Responses
{
    public class OkWebResponse
    {
        public HttpStatusCode Code { get; }
        public string Error { get; }
        public Object Body { get; }

        public OkWebResponse(
            HttpStatusCode code = HttpStatusCode.OK,
            string error = null,
            Object body = null)
        {
            Code = code;
            Error = error;
            Body = body;
        }
    }
}