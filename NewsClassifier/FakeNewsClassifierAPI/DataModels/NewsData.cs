using Microsoft.ML.Data;

namespace FakeNewsClassifierAPI.DataModels
{
    public class NewsData
    {
        [ColumnName("title"), LoadColumn(0)]
        public string Title { get; set; }


        [ColumnName("text"), LoadColumn(1)]
        public string Text { get; set; }


        [ColumnName("subject"), LoadColumn(2)]
        public string Subject { get; set; }


        [ColumnName("date"), LoadColumn(3)]
        public string Date { get; set; }


        [ColumnName("classified"), LoadColumn(4), LoadColumnName("Label")]
        public string Classified { get; set; }
    }
}
