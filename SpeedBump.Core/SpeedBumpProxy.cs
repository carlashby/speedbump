using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace SpeedBump.Core
{
    public class SpeedBumpProxyMiddlewear
    {
        public SpeedBumpProxyMiddlewear( RequestDelegate next )
        {

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

            var delay = await requestAnalyzer.CalculateMillisecondDelay( context.Request );

            await Task.Delay( delay );

            // TODO
            // forward request to backing service, using internal DNS or lookup service?

        }
    }
}
