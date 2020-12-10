using Microsoft.ML.Data;
using System;

namespace FakeNewsClassifierAPI.DataModels
{
    public class NewsPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }

        public float[] Score { get; set; }
    }
}
