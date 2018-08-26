using Microsoft.AspNetCore.Http;
using SpeedBump.Core.Models;
using System;
using System.Threading.Tasks;

namespace SpeedBump.Core
{
    public class SpeedBumpProxyMiddlewear
    {
        private readonly SpeedBumpConfig _config;

        public SpeedBumpProxyMiddlewear( RequestDelegate next, SpeedBumpConfig config)
        {
            _config = config;
        }

        public async Task InvokeAsync( HttpContext context, IRequestAnalyzer requestAnalyzer )
        {
            if (context == null)
            {
                throw new ArgumentNullException( "context" );
            }

            if (requestAnalyzer == null)
            {
                throw new ArgumentNullException( "requestAnalyzer" );
            }

            if (_config == null)
            {
                throw new Exception("SpeedBumpConfig was not provided");
            }

            if (_config.Enabled)
            {
                var delay = await requestAnalyzer.CalculateMillisecondDelay(context.Request);

                await Task.Delay(delay);
            }
            // TODO
            // forward request to backing service, using internal DNS or lookup service?

        }
    }
}
