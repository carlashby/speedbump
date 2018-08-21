using Microsoft.AspNetCore.Builder;

namespace SpeedBump.Core
{
    public static class SpeedBumpProxyMiddlewearExtensions
    {
        public static void RunSpeedbump( this IApplicationBuilder builder )
        {
            builder.UseMiddleware<SpeedBumpProxyMiddlewear>();
        }
    }
}
