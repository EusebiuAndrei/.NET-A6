using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual News News { get; set; }
    }
}