using System;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;
using Booking.BusinessLayer.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Booking.Api.Middlewares
{
    public class GlobalApiErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalApiErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var responseBodyMessage = string.Empty;
                HttpStatusCode responseBodyCode;
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int) HttpStatusCode.OK;
                switch (error)
                {
                    case DbException dbException:
                    {
                        responseBodyCode = HttpStatusCode.BadRequest;
                        responseBodyMessage = "Database connection fail: " + dbException.Message;
                        break;
                    }
                    default:
                    {
                        responseBodyCode = HttpStatusCode.InternalServerError;
                        responseBodyMessage = "Unhandled error: " + error.Message;
                        break;
                    }
                }

                var result = JsonConvert.SerializeObject(
                    new OkWebResponse(
                        code: responseBodyCode, 
                        error: responseBodyMessage, 
                        body: null));
                
                await response.WriteAsync(result);
            }
        }
    }
}