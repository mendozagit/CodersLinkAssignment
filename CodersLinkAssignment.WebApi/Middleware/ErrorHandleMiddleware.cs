using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using CodersLinkAssignment.Aplication.Exeptions;
using CodersLinkAssignment.Aplication.Wrappers;
using Microsoft.AspNetCore.Http;

namespace CodersLinkAssignment.WebApi.Middleware
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>()
                {
                    Success = false,
                    Message = exception?.Message
                };


                switch (exception)
                {
                    case ApiExeption e:
                        // custom application exception
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ValidationException e:
                        // custom application exception
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;

                        break;

                    case KeyNotFoundException e:
                        // not found exception
                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        break;

                    default:
                        // unhandle error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
