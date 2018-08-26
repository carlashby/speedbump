using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeedBump.Core;
using System;
using System.Threading.Tasks;

namespace SpeedBump.Test
{
    [TestClass]
    public class SpeedBumpProxyTests
    {
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public async Task SpeedBumpProxy_NullContext_Exception()
        {

            var proxy = new SpeedBumpProxyMiddlewear( null, null );
            await proxy.InvokeAsync( null, null );
        }

        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public async Task SpeedBumpProxy_NullAnalyzer_Exception()
        {

            var proxy = new SpeedBumpProxyMiddlewear( null, null );
            await proxy.InvokeAsync( new DefaultHttpContext(), null );
        }
    }
}
