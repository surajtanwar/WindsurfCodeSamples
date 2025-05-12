using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using nuisample.Models;

namespace nuisample.Views
{
    public class HomePageView : View
    {
        public HomePageView(List<PostModel> featuredPosts, List<PostModel> categoryPosts)
        {
            var window = Window.Instance;
            Size2D = new Size2D(window.Size.Width, window.Size.Height);
            BackgroundColor = Color.White;

            // HEADER
            var header = new View
            {
                Size2D = new Size2D(window.Size.Width, 100),
                Position2D = new Position2D(0, 0),
                BackgroundColor = Color.White
            };
            var logo = new TextLabel
            {
                Text = "LOGO",
                PointSize = 18.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(30, 30),
                Size2D = new Size2D(120, 40)
            };
            header.Add(logo);
            var menu = new TextLabel
            {
                Text = "Menu    Menu    Menu    Menu",
                PointSize = 10.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(200, 40),
                Size2D = new Size2D(300, 30)
            };
            header.Add(menu);
            var search = new TextField
            {
                PlaceholderText = "Search",
                Position2D = new Position2D(window.Size.Width - 220, 35),
                Size2D = new Size2D(180, 30),
                BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1),
                HorizontalAlignment = HorizontalAlignment.Begin
            };
            header.Add(search);
            Add(header);

            // FEATURED POSTS TITLE
            var featuredTitle = new TextLabel
            {
                Text = "Featured Posts",
                PointSize = 14.0f,
                TextColor = Color.Black,
                Position2D = new Position2D(30, 120),
                Size2D = new Size2D(300, 40)
            };
            Add(featuredTitle);
            var moreFeatured = new TextLabel
            {
                Text = "More →",
                PointSize = 10.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width - 120, 130),
                Size2D = new Size2D(80, 30),
                HorizontalAlignment = HorizontalAlignment.End
            };
            Add(moreFeatured);

            // FEATURED POSTS CARDS
            for (int i = 0; i < featuredPosts.Count; i++)
            {
                var card = CreatePostCard(
                    featuredPosts[i],
                    new Position2D(30 + i * (window.Size.Width / 2), 180),
                    new Size2D((window.Size.Width / 2) - 50, 220),
                    true
                );
                Add(card);
            }

            // CATEGORY TITLE
            var categoryTitle = new TextLabel
            {
                Text = "Category",
                PointSize = 14.0f,
                TextColor = Color.Black,
                Position2D = new Position2D(30, 430),
                Size2D = new Size2D(300, 40)
            };
            Add(categoryTitle);
            var moreCategory = new TextLabel
            {
                Text = "More →",
                PointSize = 10.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width - 120, 440),
                Size2D = new Size2D(80, 30),
                HorizontalAlignment = HorizontalAlignment.End
            };
            Add(moreCategory);

            // CATEGORY CARDS
            if (categoryPosts.Count > 0)
            {
                var categoryCardLarge = CreatePostCard(categoryPosts[0], new Position2D(30, 490), new Size2D((window.Size.Width / 2) - 50, 220), true);
                Add(categoryCardLarge);
            }
            for (int i = 1; i < categoryPosts.Count; i++)
            {
                var card = CreatePostCard(
                    categoryPosts[i],
                    new Position2D(window.Size.Width / 2 + 20, 490 + (i - 1) * 120),
                    new Size2D((window.Size.Width / 2) - 50, 100),
                    false
                );
                Add(card);
            }

            // FOOTER
            var footer = new View
            {
                Size2D = new Size2D(window.Size.Width, 80),
                Position2D = new Position2D(0, window.Size.Height - 80),
                BackgroundColor = new Color(0.13f, 0.13f, 0.13f, 1)
            };
            var footerLogo = new TextLabel
            {
                Text = "LOGO",
                PointSize = 14.0f,
                TextColor = Color.White,
                Position2D = new Position2D(30, 20),
                Size2D = new Size2D(120, 40)
            };
            footer.Add(footerLogo);
            var footerLinks = new TextLabel
            {
                Text = "Additional Link    Additional Link    Additional Link",
                PointSize = 8.0f,
                TextColor = Color.White,
                Position2D = new Position2D(200, 30),
                Size2D = new Size2D(400, 30)
            };
            footer.Add(footerLinks);
            var copyright = new TextLabel
            {
                Text = "© Your Company 2022. We love you!",
                PointSize = 8.0f,
                TextColor = Color.White,
                Position2D = new Position2D(window.Size.Width - 350, 50),
                Size2D = new Size2D(320, 20)
            };
            footer.Add(copyright);
            Add(footer);
        }

        private View CreatePostCard(PostModel post, Position2D pos, Size2D size, bool large)
        {
            var card = new View
            {
                Position2D = pos,
                Size2D = size,
                BackgroundColor = new Color(0.95f, 0.95f, 0.95f, 1),
                CornerRadius = 12.0f
            };
            var img = new ImageView
            {
                Position2D = new Position2D(0, 0),
                Size2D = new Size2D(size.Width, large ? size.Height - 70 : size.Height - 40),
                BackgroundColor = new Color(0.85f, 0.85f, 0.85f, 1)
            };
            card.Add(img);
            var info = new View
            {
                Position2D = new Position2D(0, large ? size.Height - 70 : size.Height - 40),
                Size2D = new Size2D(size.Width, large ? 70 : 40),
                BackgroundColor = Color.White
            };
            var title = new TextLabel
            {
                Text = post.Title,
                PointSize = 9.0f,
                TextColor = Color.Black,
                Position2D = new Position2D(10, 0),
                Size2D = new Size2D(100, 30)
            };
            info.Add(title);
            var category = new TextLabel
            {
                Text = post.Category,
                PointSize = 8.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(size.Width - 90, 0),
                Size2D = new Size2D(80, 30),
                HorizontalAlignment = HorizontalAlignment.End
            };
            info.Add(category);
            var author = new TextLabel
            {
                Text = post.Author + "    • " + post.TimeAgo,
                PointSize = 7.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(10, 25),
                Size2D = new Size2D(160, 20)
            };
            info.Add(author);
            var desc = new TextLabel
            {
                Text = post.Description,
                PointSize = 7.0f,
                TextColor = Color.Black,
                Position2D = new Position2D(10, 45),
                Size2D = new Size2D(size.Width - 20, 20),
                MultiLine = true
            };
            if (large) info.Add(desc);
            card.Add(info);
            return card;
        }
    }
}
