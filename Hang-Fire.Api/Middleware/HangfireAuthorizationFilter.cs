using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Hang_Fire.Api.Middleware
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        //public bool Authorize([NotNull] DashboardContext context)
        //{
        //    var httpContext = context.GetHttpContext();

        //    if(!httpContext.User.Identity.IsAuthenticated)
        //        return false;

        //    return httpContext.User.IsInRole("Admin");
        //}
        public bool Authorize([NotNull] DashboardContext context) => true;

    }
}
