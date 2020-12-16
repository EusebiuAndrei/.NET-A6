using CrawlerAPI.Controllers;
using Xunit;

namespace CrawlerAPI.Tests
{
    public class CrawlerControllerTest
    {
        private NewsController _newsController;

        public CrawlerControllerTest()
        {
            _newsController = new NewsController();
        }

        [Fact]
        public void GivenWebsiteAndSubjectWhenGetAllNewsThenListIsNotNull()
        {
            string website = "abcnews";
            string subject = "politics";
            var actionResultTask = _newsController.GetNews(website, subject);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result;
            Assert.NotNull(viewResult);
        }

        [Fact]
        public void GivenWebsiteAndSubjectWhenGetLatestNewsThenListIsNotNull()
        {
            string website = "bbc";
            string subject = "sport";
            var actionResultTask = _newsController.GetLatestNews(website, subject);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result;
            Assert.NotNull(viewResult);
        }
    }
}
