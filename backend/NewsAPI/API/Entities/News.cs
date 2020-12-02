using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string SourceLink { get; set; }
        public int ClassifiedAs { get; set; }
    }
}