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
        public Int16 ClassifiedAs { get; set; }
        public int Views { get; set; }
        public int Read { get; set; }
        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
    }
}