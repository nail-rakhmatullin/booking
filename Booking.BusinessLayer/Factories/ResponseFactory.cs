using System.Net;
using Booking.BusinessLayer.Responses;

namespace Booking.BusinessLayer.Factories
{
    public class ResponseFactory : IResponseFactory
    {
        public OkWebResponse Create(HttpStatusCode code, string error, object body)
        {
            return new OkWebResponse(code, error, body);
        }

        public OkWebResponse Create(object body)
        {
            return new OkWebResponse(body: body);
        }

        public OkWebResponse Update(HttpStatusCode code, string error, object body)
        {
            return new OkWebResponse(code, error, body);
        }

        public OkWebResponse Update(object body)
        {
            return new OkWebResponse(body: body);
        }
    }
}