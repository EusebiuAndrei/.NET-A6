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
            //Arrange
            string website = "abcnews";
            string subject = "politics";
            //Act
            var actionResultTask = _newsController.GetNews(website, subject);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result;
            //Assert
            Assert.NotNull(viewResult);
        }

        [Fact]
        public void GivenWebsiteAndSubjectWhenGetLatestNewsThenListIsNotNull()
        {
            //Arrange
            string website = "bbc";
            string subject = "sport";
            //Act
            var actionResultTask = _newsController.GetLatestNews(website, subject, 5);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result;
            //Assert
            Assert.NotNull(viewResult);
        }

    }
}
