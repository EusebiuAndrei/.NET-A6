using API.Entities;

namespace API.Views
{
    public static class NewsMapper
    {
        public static NewsViewModel getViewModel(this News item) {
            var obj = new NewsViewModel() {
                Id = item.Id,
                Title = item.Title,
                Date = item.Date,
                Text = item.Text,
                SourceLink = item.SourceLink,
                ClassifiedAs = item.ClassifiedAs,
                Views = item.Views,
                Read = item.Read,
                Topic = item.Topic
            };
            return obj;
        }
    }
}