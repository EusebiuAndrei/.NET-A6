using System;
using System.IO;
using FakeNewsClassifierAPI.DataModels;
using Microsoft.ML;

namespace ML_NET_modelML.Model
{
    public class ConsumeModel
    {
        private static Lazy<PredictionEngine<NewsData, NewsPrediction>> PredictionEngine = new Lazy<PredictionEngine<NewsData, NewsPrediction>>(CreatePredictionEngine);

        public static NewsPrediction Predict(NewsData input)
        {
            NewsPrediction result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static PredictionEngine<NewsData, NewsPrediction> CreatePredictionEngine()
        {
            MLContext mlContext = new MLContext();
            string modelPath = Path.Combine(Environment.CurrentDirectory, @"MLModels", "MLModel.zip");
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var NewsDataSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<NewsData, NewsPrediction>(mlModel);

            return predEngine;
        }
    }
}
