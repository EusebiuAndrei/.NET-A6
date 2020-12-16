using CrawlerAPI.CrawlingFunctions.CrawlingFunctionsABCNews;
using CrawlerAPI.CrawlingFunctions.CrawlingFunctionsBBC;
using CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes;
using CrawlerAPI.NewsModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions
{
    public class MappingCrawlingMethods
    {
        private Dictionary<string, Dictionary<string, Func<Task<List<News>>>>> _mappingMethods;
        public MappingCrawlingMethods()
        {
            _mappingMethods = new Dictionary<string, Dictionary<string, Func<Task<List<News>>>>>
            {
                {"abcnews", new Dictionary<string, Func<Task<List<News>>>>
                    {
                        {"all", AllNewsABC.GetNews},
                        {"entertainment", EntertainmentCrawlerABCNews.GetEntertainmentNews},
                        {"politics", PoliticsCrawlerABCNews.GetPoliticsNews},
                        {"sport", SportCrawlerABCNews.GetSportNews},
                        {"technology", TechnologyCrawlerABCNews.GetTechnologyNews},
                        {"world", WorldCrawlerABCNews.GetWorldNews}
                    }
                },
                {"bbc", new Dictionary<string, Func<Task<List<News>>>>
                    {
                        {"all", AllNewsBBC.GetNews},
                        {"business", BusinessCrawlerBBC.GetBusinessNews},
                        {"coronavirus", CoronavirusCrawlerBBC.GetCoronavirusNews},
                        {"health", HealthCrawlerBBC.GetHealthNews},
                        {"sport", SportCrawlerBBC.GetSportNews},
                        {"world", WorldCrawlerBBC.GetWorldNews}
                    }
                },
                {"thenewyorktimes", new Dictionary<string, Func<Task<List<News>>>>
                    {
                        {"all", AllNewsNYTimes.GetNews},
                        {"business", BusinessCrawlerTheNewYorkTimes.GetBusinessNews},
                        {"health", HealthCrawlerTheNewYorkTimes.GetHealthNews},
                        {"politics", PoliticsCrawlerTheNewYorkTimes.GetPoliticsNews},
                        {"sport", SportCrawlerTheNewYorkTimes.GetSportNews},
                        {"technology", TechnologyCrawlerTheNewYorkTimes.GetTechnologyNews}
                    }
                },
                {"all", new Dictionary<string, Func<Task<List<News>>>>
                    {
                        {"all", MergeNewsWebsitesFunctions.GetAllNews},
                        {"sport", MergeNewsWebsitesFunctions.GetAllSportNews},
                        {"business", MergeNewsWebsitesFunctions.GetAllBusinessNews},
                        {"coronavirus", MergeNewsWebsitesFunctions.GetAllCoronavirusNews},
                        {"health", MergeNewsWebsitesFunctions.GetAllHealthNews},
                        {"world", MergeNewsWebsitesFunctions.GetAllWorldNews},
                        {"entertainment", MergeNewsWebsitesFunctions.GetAllEntertainmentNews},
                        {"politics", MergeNewsWebsitesFunctions.GetAllPoliticsNews},
                        {"technology", MergeNewsWebsitesFunctions.GetAllTechnologyNews}
                    }
                }
            };
        }

        public async Task<List<News>> GetNewsFromWebsiteWithSubject(string website, string subject)
        {
            return await _mappingMethods[website][subject]();
        }

        public async Task<List<News>> GetLatestNewsFromWebsiteWithSubject(string website, string subject)
        {
            var allNewsList = await _mappingMethods[website][subject]();
            List<News> filteredList = new List<News>();
            foreach(var news in allNewsList)
            {
                if (Int32.Parse(news.Date.ToString("HH")) >= Int32.Parse(DateTime.Now.ToString("HH")) - 3 && Int32.Parse(news.Date.ToString("HH")) <= Int32.Parse(DateTime.Now.ToString("HH")))
                {
                    filteredList.Add(news);
                }
            }
            return filteredList;
        }
    }
}
