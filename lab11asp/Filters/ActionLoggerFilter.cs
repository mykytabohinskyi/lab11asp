using Microsoft.AspNetCore.Mvc.Filters;

namespace lab11asp.Filters
{
    public class ActionLoggerFilter : Attribute, IAsyncActionFilter
    {
        private readonly FileLogger logger;

        public ActionLoggerFilter()
        {
            this.logger = new FileLogger(@"actionlog.txt");
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            logger.LogInformation($"{context.RouteData.Values["action"] as string} method " +
                $"executing at {DateTime.Now.ToLongTimeString()}");
            await next();
        }

    }
}

