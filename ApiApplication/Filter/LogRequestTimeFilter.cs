using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System;

namespace ApiApplication.Filter
{
    public class LogRequestTimeFilter : IActionFilter
    {
        private Stopwatch stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Request took {elapsedMilliseconds} ms");
        }
    }
}
