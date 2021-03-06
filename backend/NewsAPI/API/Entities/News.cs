using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class News
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string SourceLink { get; set; }
        public string SourceImage { get; set; }
        public Int16 ClassifiedAs { get; set; }
        public int Views { get; set; }
        public int Read { get; set; }
        public int TopicId { get; set; }

        [JsonIgnore]
        public virtual Topic Topic { get; set; }
    }
}