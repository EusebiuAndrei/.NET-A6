using FakeNewsClassifierAPI.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FakeNewsClassifierAPI.Controllers
{
    [Route("api/v1/validator")]
    [ApiController]
    public class FakeNewsClassifierController : ControllerBase
    {

        public FakeNewsClassifierController(){}

        [HttpPost]
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
    }
}
