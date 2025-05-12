namespace nuisample.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string TimeAgo { get; set; }
        public bool IsFeatured { get; set; }
    }
}
