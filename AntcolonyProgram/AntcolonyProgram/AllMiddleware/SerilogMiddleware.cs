using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntcolonyProgram.AllMiddleware
{
    public class SerilogMiddleware
    {

        private readonly RequestDelegate _next;

        private readonly ILogger _logger;
        public SerilogMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger<SerilogMiddleware>();
        }
        /// <summary>
        /// 执行的方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            //执行超作
            _logger.LogInformation("My Ip:" + context.Connection.RemoteIpAddress.ToString());




            //执行下一个中间件
            await _next.Invoke(context);
        }
    }
}
