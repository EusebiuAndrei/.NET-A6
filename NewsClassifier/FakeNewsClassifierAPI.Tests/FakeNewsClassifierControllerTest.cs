using FakeNewsClassifierAPI.Controllers;
using FakeNewsClassifierAPI.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using Xunit;

namespace FakeNewsClassifierAPI.Tests
{
    public class FakeNewsClassifierControllerTest
    {
        private FakeNewsClassifierController _fakeNewsClassifierCotroller;
        public NewsData news = new NewsData
        {
            Title = "\"If all goes 'well' it'll become federal law to get the (COVID-19) vaccine.\"",
            Text = "A Facebook post about Moderna’s COVID-19 vaccine is filled with falsehoods. The Dec. 8 post alleges that infectious disease expert Dr.Anthony Fauci, Microsoft co - founder Bill Gates, billionaire George Soros, and the late financier and convicted sex offender Jeffrey Epstein are all connected to Moderna Inc. Moderna is a Massachusetts - based biotech company that’s developing a vaccine against COVID - 19.But none of the alleged connections mentioned in the post are true.We rated that aspect of the claim Pants on Fire, when it surfaced in a separate post in August. The August and Dec. 8 posts also claim that \"if all goes ‘well’ it'll become federal law to get the vaccine.\" Is that part true ? No. The post was flagged as part of Facebook’s efforts to combat false news and misinformation on its News Feed. (Read more about our partnership with Facebook.) Moderna at the end of November said it would ask the U.S.Food and Drug Administration to grant emergency use authorization for its vaccine, based on Phase 3 study data indicating that the vaccine was 94.1 % effective against COVID - 19. The company itself has no authority to make its vaccine mandatory. The Trump administration has not said it would make any COVID-19 vaccine mandatory. President-elect Joe Biden has not said he would mandate it either.The federal government has invested more than $9 billion in vaccine deals with multiple private companies. The agreements vary in scope; some are only for the purchase of vaccines, others provide funding for the research, manufacturing and purchase of vaccines. But the messaging from the Trump administration so far has been about voluntary vaccination. A report from the U.S. Health and Human Services Department talks about \"ensuring that every American who wants to receive a COVID - 19 vaccine can receive one.\""
        };

        public FakeNewsClassifierControllerTest()
        {
            _fakeNewsClassifierCotroller = new FakeNewsClassifierController();
        }

        [Fact]
        public void CheckBadResponseOnPost()
        {
            // Act
            var badResponse = _fakeNewsClassifierCotroller.Post(news);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void CheckOkResponseOnPost()
        {
            // Act
            var okResult = _fakeNewsClassifierCotroller.Post(news);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void CheckPostResult()
        {
            // Act
            var result = _fakeNewsClassifierCotroller.Post(news).Value;
            // Assert
            Debug.WriteLine(result);
            bool boolResult = result == "0" ? false : true;
            Assert.True(boolResult);
        }
    }
}
