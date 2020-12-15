using System;
using API.Entities;

namespace API.Views
{
    public class NewsViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string SourceLink { get; set; }
        public Int16 ClassifiedAs { get; set; }
        public int Views { get; set; }
        public int Read { get; set; }
        public Topic Topic { get; set; }
    }
}