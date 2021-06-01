namespace RepositoryLayer.Interface
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IHttpClientRepository
    {
        /// <summary>
        /// Get Async
        /// </summary>
        /// <param name="apiRelativePath">Relative path of the API</param>
        /// <returns>HttpResponseMessage object</returns>
        Task<HttpResponseMessage> GetAsync(string apiRelativePath);
    }
}
