using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class NewsTopic
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int TopicId { get; set; }
    }
}