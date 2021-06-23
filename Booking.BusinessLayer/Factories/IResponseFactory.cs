using System.Net;
using Booking.BusinessLayer.Responses;

namespace Booking.BusinessLayer.Factories
{
    public interface IResponseFactory
    {
        OkWebResponse Create(HttpStatusCode code, string error, object body);
        OkWebResponse Create(object body);

        OkWebResponse Update(HttpStatusCode code, string error, object body);
        OkWebResponse Update(object body);
    }
}