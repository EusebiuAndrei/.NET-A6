using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class NewsTopic
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int TopicId { get; set; }

        public virtual News news { get; set; }
        public virtual Topic topic { get; set; }
    }
}