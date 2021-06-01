using AutoMapper;
using Common.Constants;
using Common.Exceptions;
using Newtonsoft.Json;
using RepositoryLayer.Interface;
using ServiceLayer.DTO;
using ServiceLayer.Helper;
using ServiceLayer.Interface;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ServiceLayer.Class
{
    public class GuardianService : ISiteFactoryService
    {
        private readonly IHttpClientRepository httpClientRepository;
        private readonly IMapper mapper;

        public GuardianService(IHttpClientRepository httpClientRepository, IMapper mapper)
        {
            this.httpClientRepository = httpClientRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get paginated Site news
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsData>> GetSiteNews(FilterDTO filterDTO)
        {
            HttpResponseMessage httpResponseMessage = await this.httpClientRepository.GetAsync(ParameterHelper.ParseQueryParameters(filterDTO));
            Guardian siteNewsDTO = new Guardian();
            List<NewsData> newsDTO = new List<NewsData>();
            string body = string.Empty;

            if (httpResponseMessage == null)
            {
                throw new ServiceLayerException(ErrorMessages.HttpResponseError);
            }

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                httpResponseMessage.EnsureSuccessStatusCode();
                body = await httpResponseMessage.Content.ReadAsStringAsync();
                siteNewsDTO = JsonConvert.DeserializeObject<Guardian>(body);
                newsDTO = this.mapper.Map<List<NewsData>>(siteNewsDTO.Response.Results);
            }
            else {
                body = await httpResponseMessage.Content.ReadAsStringAsync();
                throw new ServiceLayerException(body);
            }

            return newsDTO;
        }
    }
}
