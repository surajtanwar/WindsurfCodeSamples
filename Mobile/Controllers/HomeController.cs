using System.Collections.Generic;
using nuisample.Models;

namespace nuisample.Controllers
{
    public class HomeController
    {
        public List<PostModel> GetFeaturedPosts()
        {
            return new List<PostModel>
            {
                new PostModel { Title = "Post Title", Author = "Author", Category = "Category", Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur.", TimeAgo = "8 min ago", IsFeatured = true },
                new PostModel { Title = "Post Title", Author = "Author", Category = "Category", Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur.", TimeAgo = "8 min ago", IsFeatured = true }
            };
        }
        public List<PostModel> GetCategoryPosts()
        {
            return new List<PostModel>
            {
                new PostModel { Title = "Post Title", Author = "Author", Category = "Category", Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur.", TimeAgo = "8 min ago", IsFeatured = true },
                new PostModel { Title = "Post Title", Author = "Author", Category = "Category", Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur.", TimeAgo = "8 min ago", IsFeatured = false },
                new PostModel { Title = "Post Title", Author = "Author", Category = "Category", Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur.", TimeAgo = "8 min ago", IsFeatured = false }
            };
        }
    }
}
