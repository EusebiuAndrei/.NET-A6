namespace API.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual News News { get; set; }
    }
}