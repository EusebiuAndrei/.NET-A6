﻿using System.Threading.Tasks;
using CrawlerAPI.NewsModel;
using System.Collections.Generic;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsBBC
{
    public static class SportCrawlerBBC
    {
        public static async Task<List<News>> GetSportNews()
        {
            return await CrawlerBBC.StartCrawlerAsync("https://www.bbc.co.uk/sport", new string[] { "gel-layout__item gel-1/3@m gel-1/4@xxl sp-o-keyline sp-o-no-keyline@m" }, "sport");
        }
    }
}
