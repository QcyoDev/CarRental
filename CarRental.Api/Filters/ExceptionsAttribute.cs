using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarRental.Api.Filters
{
    public class ExceptionsAttribute : Attribute, IExceptionFilter
    {
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnException(ExceptionContext context)
        {
            var errorDetail = new ErrorDetailModel();
            errorDetail.State = HttpStatusCode.InternalServerError.ToString();
            errorDetail.StatusCode = (int)HttpStatusCode.InternalServerError;
            errorDetail.Detail = context.Exception.Message;
            errorDetail.Errors.Add(new Error
            {
                Title = context.Exception.Message,
                Detail = context.Exception.InnerException?.Message ?? string.Empty
            });

            context.Result = new ObjectResult(errorDetail);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
