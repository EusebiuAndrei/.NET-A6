using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual NewsTopic newsTopic { get; set; }
    }
}