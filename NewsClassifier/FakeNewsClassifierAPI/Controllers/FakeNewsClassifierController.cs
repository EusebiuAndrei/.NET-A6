using System;
using FakeNewsClassifierAPI.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using ML_NET_modelML.Model;

namespace FakeNewsClassifierAPI.Controllers
{
    [Route("api/v1/validator")]
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
