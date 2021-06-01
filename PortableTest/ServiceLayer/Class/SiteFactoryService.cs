// <copyright file="SiteService.cs" company="Portable">
// Copyright (c) Portable. All rights reserved.
// </copyright>
namespace ServiceLayer.Class
{
    using RepositoryLayer.Interface;
    using ServiceLayer.Interface;
    using ServiceLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Exceptions;
    using Common.Constants;
    using RepositoryLayer.Context;
    using System.Linq;

    public class SiteFactoryService : ISiteFactoryService, IPinArticleService
    {
        private readonly IPinArticleRepository pinArticleRepository;
        private readonly IHttpClientRepository httpClientRepository;
        private readonly IMapper mapper;

        public SiteFactoryService(IHttpClientRepository httpClientRepository, IPinArticleRepository pinArticleRepository, IMapper mapper)
        {
            this.httpClientRepository = httpClientRepository;
            this.pinArticleRepository = pinArticleRepository;
            this.mapper = mapper;
        }

        public async Task<List<NewsData>> GetSiteNews(FilterDTO filterDTO)
        {
            List<NewsData> newsDatas = new List<NewsData>();
            foreach (var source in filterDTO.NewsPreferences)
            {
                Type type = Type.GetType($"ServiceLayer.Class.{source}");
                if (type != null)
                {
                    ISiteFactoryService siteService = Activator.CreateInstance(type, this.httpClientRepository, this.mapper) as ISiteFactoryService;
                    var response = await siteService.GetSiteNews(filterDTO);
                    newsDatas.AddRange(response);
                }
                else
                {
                    throw new ServiceLayerException(ErrorMessages.NewPerferenceNotFound);
                }
            }
         
            return newsDatas;
        }

        public async Task PinArticle(int userId, List<PinArticleDTO> articleDTOs)
        {
            var articles = mapper.Map<List<PinArticle>>(articleDTOs);
            articles.Select(x => x.UserId = userId).ToList();
            await this.pinArticleRepository.PinArticles(articles);
        }
    }
}
