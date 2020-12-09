﻿using Microsoft.ML.Data;
using System;

namespace FakeNewsClassifierAPI.DataModels
{
    public class NewsPrediction : NewsData
    {
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }
        public float Probability { get; set; }
        public float[] Score { get; set; }
    }
}
