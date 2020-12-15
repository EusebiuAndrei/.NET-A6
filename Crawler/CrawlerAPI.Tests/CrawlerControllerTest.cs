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
        public void CheckNewsListHealthBBCNews()
        {
            // Act
            var actionResultTask = _newsController.GetHealthNewsFromBBC();
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result;
            //Assert
            Assert.NotNull(viewResult);
        }
    }
}
