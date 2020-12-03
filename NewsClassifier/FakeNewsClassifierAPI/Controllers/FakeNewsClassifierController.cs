using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeNewsClassifierAPI.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;

namespace FakeNewsClassifierAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class FakeNewsClassifierController : ControllerBase
    {
        private const string T = "True";
        private const string F = "Fake";
        private readonly PredictionEnginePool<NewsData, NewsPrediction> _predictionEnginePool;

        public FakeNewsClassifierController(PredictionEnginePool<NewsData, NewsPrediction> predictionEnginePool)
        {
            this._predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] NewsData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            NewsPrediction predictedValue = _predictionEnginePool.Predict(modelName: "FakeNewsClassifierModels", example: data);

            string news = Convert.ToBoolean(predictedValue.Prediction) ? T : F;

            return Ok(news);
        }
    }
}
