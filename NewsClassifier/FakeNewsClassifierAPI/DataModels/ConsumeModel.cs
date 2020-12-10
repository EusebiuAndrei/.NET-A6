using System;
using Microsoft.ML;
using System.IO;

namespace FakeNewsClassifierAPI.DataModels
{
    public class ConsumeModel
    {
        private static Lazy<PredictionEngine<NewsData, NewsPrediction>> PredictionEngine = new Lazy<PredictionEngine<NewsData, NewsPrediction>>(CreatePredictionEngine);

        public static NewsPrediction Predict(NewsData input)
        {
            NewsPrediction result = PredictionEngine.Value.Predict(input);
            Console.WriteLine(result.Prediction);
            foreach(var item in result.Score)
            {
                Console.WriteLine(item);
            }
            return result;
        }

        public static PredictionEngine<NewsData, NewsPrediction> CreatePredictionEngine()
        {
            MLContext mlContext = new MLContext();

            string modelPath = Path.Combine(Environment.CurrentDirectory, @"MLModels", @"MLModel.zip");
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<NewsData, NewsPrediction>(mlModel, modelInputSchema);
            return predEngine;
        }
    }
}
