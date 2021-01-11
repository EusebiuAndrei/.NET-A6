using FakeNewsClassifierAPI.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FakeNewsClassifierAPI.Controllers
{
    [Route("api/v1/validator")]
    [ApiController]
    public class FakeNewsClassifierController : ControllerBase
    {

        public FakeNewsClassifierController(){}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Post([FromBody] NewsData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            NewsPrediction predictedValue = ConsumeModel.Predict(data);

            string news = predictedValue.Prediction;

            return Ok(news);
        }

        [HttpPost("news-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> PostNewsList([FromBody] List<NewsData> newsData)
        {
            foreach(var item in newsData)
            {
                Console.WriteLine(item.Title);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            List<NewsPrediction> predictions = new List<NewsPrediction>();
            foreach(NewsData data in newsData)
            {
                predictions.Add(ConsumeModel.Predict(data));
            }
            Console.WriteLine("predicted");
            List<string> predictedValues = new List<string>();
            foreach(NewsPrediction prediction in predictions)
            {
                predictedValues.Add(prediction.Prediction);
                Console.WriteLine(prediction.Prediction);
            }

            return Ok(predictedValues);
        }
    }
}
