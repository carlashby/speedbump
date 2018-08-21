using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeedBump.Core;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace SpeedBump.Test
{
    [TestClass]
    public class RandomDelayTests
    {
        [TestMethod]
        public async Task RandomDelay_ValidRequest_ValidDelay()
        {
            IRequestAnalyzer randomDelay = new RandomDelay();

            var delay = await randomDelay.CalculateMillisecondDelay( new DefaultHttpContext().Request );

            Assert.IsTrue( delay >= 0 );
        }

        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public async Task RandomDelay_NullRequest_Exception()
        {
            IRequestAnalyzer randomDelay = new RandomDelay();

            var delay = await randomDelay.CalculateMillisecondDelay( null );

        }
    }
}
