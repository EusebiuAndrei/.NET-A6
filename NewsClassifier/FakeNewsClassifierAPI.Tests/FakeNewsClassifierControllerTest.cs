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
        private FakeNewsClassifierController _fakeNewsClassifierController;
        public NewsData trueNews = new NewsData
        {
            Title = "\"Donald Trump\"",
            Text = "Born and raised in Queens, New York City, Trump attended Fordham University for two years and received a bachelor's degree in economics from the Wharton School of the University of Pennsylvania. He became president of his father Fred Trump's real estate business in 1971, renamed it The Trump Organization, and expanded its operations to building or renovating skyscrapers, hotels, casinos, and golf courses. Trump later started various side ventures, mostly by licensing his name. Trump and his businesses have been involved in more than 4,000 state and federal legal actions, including six bankruptcies. He owned the Miss Universe brand of beauty pageants from 1996 to 2015, and produced and hosted the reality television series The Apprentice from 2004 to 2015.Trump's political positions have been described as populist, protectionist, isolationist, and nationalist. He entered the 2016 presidential race as a Republican and was elected in a surprise Electoral College victory over Democratic nominee Hillary Clinton while losing the popular vote.[a] He became the oldest first-term U.S. president[b] and the first without prior military or government service. His election and policies have sparked numerous protests. Trump has made many false or misleading statements during his campaign and presidency. The statements have been documented by fact-checkers, and the media have widely described the phenomenon as unprecedented in American politics. Many of his comments and actions have been characterized as racially charged or racist..\""
        };

        public NewsData fakeNews = new NewsData
          {  Title = "\"If all goes 'well' it'll become federal law to get the (COVID-19) vaccine.\"",
              Text = "A Facebook post about Moderna’s COVID-19 vaccine is filled with falsehoods. The Dec. 8 post alleges that infectious disease expert Dr.Anthony Fauci, Microsoft co - founder Bill Gates, billionaire George Soros, and the late financier and convicted sex offender Jeffrey Epstein are all connected to Moderna Inc. Moderna is a Massachusetts - based biotech company that’s developing a vaccine against COVID - 19.But none of the alleged connections mentioned in the post are true.We rated that aspect of the claim Pants on Fire, when it surfaced in a separate post in August. The August and Dec. 8 posts also claim that \"if all goes ‘well’ it'll become federal law to get the vaccine.\" Is that part true ? No. The post was flagged as part of Facebook’s efforts to combat false news and misinformation on its News Feed. (Read more about our partnership with Facebook.) Moderna at the end of November said it would ask the U.S.Food and Drug Administration to grant emergency use authorization for its vaccine, based on Phase 3 study data indicating that the vaccine was 94.1 % effective against COVID - 19. The company itself has no authority to make its vaccine mandatory. The Trump administration has not said it would make any COVID-19 vaccine mandatory. President-elect Joe Biden has not said he would mandate it either.The federal government has invested more than $9 billion in vaccine deals with multiple private companies. The agreements vary in scope; some are only for the purchase of vaccines, others provide funding for the research, manufacturing and purchase of vaccines. But the messaging from the Trump administration so far has been about voluntary vaccination. A report from the U.S. Health and Human Services Department talks about \"ensuring that every American who wants to receive a COVID - 19 vaccine can receive one.\""
          };

        public FakeNewsClassifierControllerTest()
        {
            _fakeNewsClassifierController = new FakeNewsClassifierController();
        }

        [Fact]
        public void GivenNewsWhenPostThenCheckBadResponse()
        {
            // Act
            var badResponse = _fakeNewsClassifierController.Post(trueNews);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void GivenNewsWhenPostThenCheckOkResponse()
        {
            // Act
            var okResult = _fakeNewsClassifierController.Post(trueNews);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GivenTrueNewsWhenPostThenCheckExpectedResult()
        {
            // Act
            var result = _fakeNewsClassifierController.Post(trueNews).Result as OkObjectResult;
            var valueReturned = result.Value;
            var valueExpected = "1";

            // Assert
            Assert.Equal(valueExpected,valueReturned);

        }

        [Fact]
        public void GivenFakeNewsWhenPostThenCheckExpectedResult()
        {
            // Act
            var result = _fakeNewsClassifierController.Post(fakeNews).Result as OkObjectResult;
            var valueReturned = result.Value;
            var valueExpected = "0";

            // Assert
            Assert.Equal(valueExpected, valueReturned);

        }
    }
}
