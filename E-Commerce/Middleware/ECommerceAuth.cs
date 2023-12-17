using Common;
using Common.LoginAndLogout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Net;

namespace E_Commerce.Middleware
{
    public class ECommerceAuth : IActionFilter // IActionFilter -- NameSpace - Microsoft.AspNetCore.Mvc.Filters
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            TokenAndSessionValidation ObjTokenAndSession = new TokenAndSessionValidation();
            if (!ObjTokenAndSession.SessionValidate(context))
            {
                LogoutInput ObjInput = new LogoutInput()
                {
                    IntUserId = Convert.ToInt32(context.HttpContext.Request.Headers["UserId"])
                };
                new UserLogout().GetLogout(ObjInput);

                string strExceptionOutput = JsonConvert.SerializeObject(new response()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    message = "Session Expired"
                });
                response.ContentType = "application/json";
                context.Result = new BadRequestObjectResult(strExceptionOutput);// BadRequestObjectResult -- NameSpace - Microsoft.AspNetCore.Mvc
            }
            if (!ObjTokenAndSession.ValidateToke(context))
            {
                string strExceptionOutput = JsonConvert.SerializeObject(new response()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    message = "Unauthorized"
                });
                response.ContentType = "application/json";
                context.Result = new BadRequestObjectResult(strExceptionOutput);// BadRequestObjectResult -- NameSpace - Microsoft.AspNetCore.Mvc
            }
        }
    }
}
