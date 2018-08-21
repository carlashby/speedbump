using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SpeedBump.Core
{
    public interface IRequestAnalyzer
    {
        Task<int> CalculateMillisecondDelay( HttpRequest request );
    }
}
