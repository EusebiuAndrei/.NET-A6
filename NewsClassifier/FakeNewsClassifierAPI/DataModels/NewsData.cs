using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNewsClassifierAPI.DataModels
{
    public class NewsData
    {
        [LoadColumn(0)]
        public string Title { get; set; }

        [LoadColumn(1)]
        public string Text { get; set; }

        [LoadColumn(4)]
        [LoadColumnName("Label")]
        public bool Classified { get; set; }
    }
}
