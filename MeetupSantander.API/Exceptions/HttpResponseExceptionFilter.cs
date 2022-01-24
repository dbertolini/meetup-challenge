using MeetupSantander.API.Data.Exceptions;
using MeetupSantander.API.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MeetupSantander.API.Exceptions
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseexception)
            {
                context.Result = new ObjectResult(httpResponseexception.Value)
                {
                    StatusCode = httpResponseexception.Status,
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is DomainException domainException)
            {
                context.Result = new ObjectResult(domainException.Value)
                {
                    StatusCode = domainException.Status,
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is DataException dataException)
            {
                context.Result = new ObjectResult(dataException.Value)
                {
                    StatusCode = dataException.Status,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
