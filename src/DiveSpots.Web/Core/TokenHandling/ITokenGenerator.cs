using System.Threading.Tasks;

namespace DiveSpots.Web.Core.TokenHandling
{
    public interface ITokenGenerator
    {
        Task<object> CreateTokenAsync(string username, string password);
    }
}