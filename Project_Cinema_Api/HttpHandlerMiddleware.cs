﻿using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Project_Cinema_Api
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException ex)
            {
                SendResponse(context, ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                SendResponse(context, ex.Message);
            }
        }

        private async void SendResponse(HttpContext context, string msg, HttpStatusCode code = HttpStatusCode.InternalServerError)
        {
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "Error",
                Detail = msg,
                Status = (int)code
            });
        }
    }
}