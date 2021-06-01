// <copyright file="ISiteService.cs" company="Portable">
// Copyright (c) Portable. All rights reserved.
// </copyright>
using ServiceLayer.DTO;
using ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface ISiteFactoryService
    {
        Task<List<NewsData>> GetSiteNews(FilterDTO filterDTO);
    }
}