using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace SpeedBump.Core
{
    public class RandomDelay : IRequestAnalyzer
    {
        public async Task<int> CalculateMillisecondDelay( HttpRequest request )
        {
            if (request == null)
            {
                throw new ArgumentNullException( "request" );
            }

            int millisecondDelay = 0;
            var random = new Random();
            var needsDelay = Convert.ToBoolean( random.Next( 0, 2 ) );

            if (needsDelay)
            {
                millisecondDelay = random.Next( 0, 6000 );
            }

            return await Task.FromResult<int>( millisecondDelay );
        }
    }
}
