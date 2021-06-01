using RepositoryLayer.Interface;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RepositoryLayer.Class
{
    public class HttpClientRepository: IHttpClientRepository
    {
        private readonly string baseAddress;
       
        public HttpClientRepository(string baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        /// <summary>
        /// Get Async
        /// </summary>
        /// <param name="apiRelativePath">Relative path of the API</param>
        /// <returns>HttpResponseMessage object</returns>
        public async Task<HttpResponseMessage> GetAsync(string apiRelativePath)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetAsync(new Uri($"{this.baseAddress}{apiRelativePath}", UriKind.Absolute));
            }
        }
    }
}
