using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace nuisample.Views
{
    public class RecipeDetailView : View
    {
        public RecipeDetailView()
        {
            var window = Window.Instance;
            Size2D = new Size2D(window.Size.Width, window.Size.Height);
            BackgroundColor = Color.White;

            // Recipe Image + Favorite Icon
            var image = new ImageView
            {
                // Use absolute path for image if needed, fallback to Home.png if not found
                ResourceUrl = System.IO.File.Exists("recipe-details.png") ? "recipe-details.png" : "Home.png",
                Size2D = new Size2D(window.Size.Width, 220),
                Position2D = new Position2D(0, 0),
                CornerRadius = 0,
                BackgroundColor = Color.White // Ensure background is not transparent
            };
            Add(image);
            var favorite = new TextLabel
            {
                Text = "♥",
                PointSize = 18.0f,
                TextColor = Color.White,
                Position2D = new Position2D(window.Size.Width - 55, 20),
                Size2D = new Size2D(35, 35),
                BackgroundColor = new Color(0,0,0,0.3f),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Add(favorite);

            // Title & Stars
            var stars = new TextLabel
            {
                Text = "★ ★ ★ ★ ☆",
                PointSize = 10.0f,
                TextColor = new Color(1, 0.8f, 0, 1),
                Position2D = new Position2D(0, 230),
                Size2D = new Size2D(window.Size.Width, 30),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(stars);
            var title = new TextLabel
            {
                Text = "Prime Rib Roast",
                PointSize = 20.0f,
                PixelSize = 36,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(0, 260),
                Size2D = new Size2D(window.Size.Width, 60),
                HorizontalAlignment = HorizontalAlignment.Center,
                MultiLine = true,
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold"))
            };
            Add(title);
            var desc = new TextLabel
            {
                Text = "The Prime Rib Roast is a classic and tender cut of beef taken from the rib primal cut. Learn how to make the perfect prime rib roast to serve your family and friends. Check out Whaot's Cooking America's award-winning Classic Prime Rib Roast recipe and photo tutorial to help you make the Perfect Prime Rib Roast.",
                PointSize = 8.0f,
                TextColor = Color.Black,
                Position2D = new Position2D(30, 300),
                Size2D = new Size2D(window.Size.Width - 60, 70),
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(desc);

            // Shopping List Title
            var shoppingIcon = new TextLabel
            {
                Text = "🛒",
                PointSize = 14.0f,
                Position2D = new Position2D(window.Size.Width/2 - 20, 380),
                Size2D = new Size2D(40, 30),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(shoppingIcon);
            var shoppingTitle = new TextLabel
            {
                Text = "SHOPPING LIST",
                PointSize = 10.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width/2 - 80, 410),
                Size2D = new Size2D(160, 30),
                HorizontalAlignment = HorizontalAlignment.Center,
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold"))
            };
            Add(shoppingTitle);

            // Shopping List Items
            string[] shopping = new string[] {
                "1 Prime Rib Roast (standing rib), approximately 8 pounds",
                "1/2 cup good-quality balsamic vinegar",
                "1 cup (packed) Italian parsley leaves",
                "8 cloves garlic, minced",
                "1/4 teaspoon salt",
                "Freshly ground pepper to taste",
                "1 cup water",
                "3 drops Worcestershire sauce"
            };
            for (int i=0; i<shopping.Length; i++)
            {
                var item = new TextLabel
                {
                    Text = "• " + shopping[i],
                    PointSize = 10.0f,
                    PixelSize = 22,
                    TextColor = Color.Black,
                    Position2D = new Position2D(40, 440 + i*38),
                    Size2D = new Size2D(window.Size.Width-80, 38),
                    MultiLine = true,
                    Ellipsis = false // Prevent '...'
                };
                Add(item);
            }

            // Preparation Title
            var prepIcon = new TextLabel
            {
                Text = "📝",
                PointSize = 14.0f,
                Position2D = new Position2D(window.Size.Width/2 - 20, 675),
                Size2D = new Size2D(40, 30),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(prepIcon);
            var prepTitle = new TextLabel
            {
                Text = "PREPARATION",
                PointSize = 10.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width/2 - 80, 705),
                Size2D = new Size2D(160, 30),
                HorizontalAlignment = HorizontalAlignment.Center,
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold"))
            };
            Add(prepTitle);

            string[] steps = new string[] {
                "Preheat oven to 350 degrees F. Let roast stand at room temperature for 1 hour.",
                "In a small saucepan over medium-high heat, boil balsamic vinegar until it reduces to 1/4 cup, approximately 3 minutes. Remove from heat and set aside.",
                "Finely mince the parsley. Mix together with the minced garlic, 1/4 teaspoon salt, and a generous amount of pepper. Using the tip of a sharp knife, bore 7 to 10 narrow holes, each about 1 1/2" deep, in the rib roast. Fill the holes with the parsley-garlic mixture. Spread any remaining mixture over the surface of the roast. Sprinkle all sides of the meat with salt and pepper.",
                "After slicing the roast, add any accumulated meat juices to the balsamic sauce. Serve the meat slices on warmed plates with balsamic sauce on the side."
            };
            for (int i=0; i<steps.Length; i++)
            {
                var step = new TextLabel
                {
                    Text = "✔ " + steps[i],
                    PointSize = 8.0f,
                    TextColor = Color.Black,
                    Position2D = new Position2D(40, 735 + i*48),
                    Size2D = new Size2D(window.Size.Width-80, 48),
                    MultiLine = true
                };
                Add(step);
            }

            // Comments Title
            var commentIcon = new TextLabel
            {
                Text = "💬",
                PointSize = 14.0f,
                Position2D = new Position2D(window.Size.Width/2 - 20, 950),
                Size2D = new Size2D(40, 30),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(commentIcon);
            var commentTitle = new TextLabel
            {
                Text = "COMMENTS",
                PointSize = 10.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width/2 - 80, 980),
                Size2D = new Size2D(160, 30),
                HorizontalAlignment = HorizontalAlignment.Center,
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold"))
            };
            Add(commentTitle);

            // Comments
            var comments = new List<(string, string, string, string, int)>
            {
                ("TOM KLEIN", "This prime rib roast was amazing!!!", "7.01.2017", "★☆☆☆☆", 1),
                ("SALLY PARKER", "I was amazed at how little preparation this took. Just rub on the herbs and butter, let it sit for a few hours and you have an amazing piece of meat!", "7.01.2017", "★★★★☆", 2)
            };
            for (int i=0; i<comments.Count; i++)
            {
                var (name, comment, date, stars, avatar) = comments[i];
                var y = 1010 + i*90;
                var avatarLabel = new TextLabel
                {
                    Text = avatar == 1 ? "👤" : "👩",
                    PointSize = 14.0f,
                    Position2D = new Position2D(30, y),
                    Size2D = new Size2D(40, 40)
                };
                Add(avatarLabel);
                var nameLabel = new TextLabel
                {
                    Text = name,
                    PointSize = 8.0f,
                    TextColor = Color.Black,
                    Position2D = new Position2D(80, y),
                    Size2D = new Size2D(180, 20),
                    FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold"))
                };
                Add(nameLabel);
                var dateLabel = new TextLabel
                {
                    Text = date,
                    PointSize = 8.0f,
                    TextColor = Color.Gray,
                    Position2D = new Position2D(270, y),
                    Size2D = new Size2D(120, 20)
                };
                Add(dateLabel);
                var starLabel = new TextLabel
                {
                    Text = stars,
                    PointSize = 10.0f,
                    TextColor = new Color(1, 0.8f, 0, 1),
                    Position2D = new Position2D(80, y+20),
                    Size2D = new Size2D(100, 20)
                };
                Add(starLabel);
                var commentLabel = new TextLabel
                {
                    Text = comment,
                    PointSize = 8.0f,
                    TextColor = Color.Black,
                    Position2D = new Position2D(80, y+40),
                    Size2D = new Size2D(window.Size.Width-120, 40),
                    MultiLine = true
                };
                Add(commentLabel);
            }

            // Comment Input
            var commentInput = new TextField
            {
                PlaceholderText = "Type your comment here...",
                Position2D = new Position2D(30, 1210),
                Size2D = new Size2D(window.Size.Width-80, 40),
                BackgroundColor = new Color(0.95f, 0.95f, 0.95f, 1),
                PointSize = 8.0f
            };
            Add(commentInput);
            var sendIcon = new TextLabel
            {
                Text = "📩",
                PointSize = 14.0f,
                Position2D = new Position2D(window.Size.Width-60, 1210),
                Size2D = new Size2D(40, 40)
            };
            Add(sendIcon);
        }
    }
}
