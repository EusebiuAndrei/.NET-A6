using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class UserPreferences
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TopicId { get; set; }
        
        [JsonIgnore]
        public virtual Topic Topic { get; set; }
    }
}