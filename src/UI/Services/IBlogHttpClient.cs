using System.Threading.Tasks;
using System.Net.Http;

namespace Client.Services
{
    public interface IBlogHttpClient
    {
        Task<HttpClient> GetClient();
    }
}