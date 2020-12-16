using API.Controllers;
using API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace NewsAPI.Tests
{
    public class UnitTest1
    {
        private DbContextOptions<DataContext> options;
        private NewsController _newsController;
        private INewsRepository _repository;
        private DataContext _dbContext;
        
        public UnitTest1()
        {
            _dbContext = new DataContext(options);
            _repository = new NewsRepository(_dbContext);
            _newsController = new NewsController(_repository);
        }

        [Fact]
        public void Test1()
        {
            var result = _newsController.Get();

            Assert.NotNull(result);

        }
    }
}
