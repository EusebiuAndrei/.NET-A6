using System;

namespace API.Entities
{
    public class NewsFromCrawling
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string SourceLink { get; set; }
        public string ImageSource { get; set; }
    }
}
