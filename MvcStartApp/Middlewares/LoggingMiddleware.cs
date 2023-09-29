using System;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MvcStartApp.Models;


namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        public readonly RequestDelegate _next;
        
  
        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
           
        }
  
        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            var repository = context.RequestServices.GetService<IRequestRepository>();
            var request = new Request()
            {
                Url = context.Request.GetDisplayUrl()
            };
            await repository.AddRequest(request);
            
                // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
      
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}