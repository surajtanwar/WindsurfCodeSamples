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

            // Create a scrollable container
            var scroll = new ScrollableBase
            {
                Size2D = new Size2D(window.Size.Width, window.Size.Height),
                Position2D = new Position2D(0, 0),
            };
            Add(scroll);

            // Content container for all UI elements
            var contentView = new View
            {
                Size2D = new Size2D(window.Size.Width, 1850), // Set height to fit all content
                Position2D = new Position2D(0, 0),
                BackgroundColor = Color.White
            };
            scroll.Add(contentView);

            // Recipe Image + Favorite Icon
            var image = new ImageView
            {
                ResourceUrl = "recipe-details.png",
                Size2D = new Size2D(window.Size.Width, 220),
                Position2D = new Position2D(0, 0),
                CornerRadius = 0,
                BackgroundColor = Color.White // Ensure background is not transparent
            };
            contentView.Add(image);
            var favorite = new TextLabel
            {
                Text = "♥",
                PointSize = 18.0f,
                TextColor = Color.White,
                Position2D = new Position2D(window.Size.Width - 55, 40), // Increased gap below image
                Size2D = new Size2D(35, 35),
                BackgroundColor = new Color(0,0,0,0.3f),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            contentView.Add(favorite);

            // Title & Stars
            var stars = new TextLabel
            {
                Text = "★ ★ ★ ★ ☆",
                PointSize = 10.0f,
                TextColor = new Color(1, 0.8f, 0, 1),
                Position2D = new Position2D(0, 270), // Increased gap below favorite
                Size2D = new Size2D(window.Size.Width, 30),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            contentView.Add(stars);
            var title = new TextLabel
            {
                Text = "Prime Rib Roast",
                PointSize = 20.0f,
                PixelSize = 36,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(0, 310), // Increased gap below stars
                Size2D = new Size2D(window.Size.Width, 60),
                HorizontalAlignment = HorizontalAlignment.Center,
                MultiLine = true,
                FontStyle = new PropertyMap().contentView.Add("weight", new PropertyValue("bold"))
            };
            contentView.Add(title);
            var desc = new TextLabel
            {
                Text = "The Prime Rib Roast is a classic and tender cut of beef taken from the rib primal cut. Learn how to make the perfect prime rib roast to serve your family and friends. Check out Whaot's Cooking America's award-winning Classic Prime Rib Roast recipe and photo tutorial to help you make the Perfect Prime Rib Roast.",
                PointSize = 10.0f,
                PixelSize = 22,
                TextColor = Color.Black,
                Position2D = new Position2D(30, 380), // Increased gap below title
                Size2D = new Size2D(window.Size.Width - 60, 120), // Increased height
                MultiLine = true,
                Ellipsis = false, // Prevent '...'
                HorizontalAlignment = HorizontalAlignment.Center
            };
            contentView.Add(desc);

            // Shopping List Title
            var shoppingIcon = new ImageView
            {
                ResourceUrl = "icon.png",
                Size2D = new Size2D(40, 40),
                Position2D = new Position2D(window.Size.Width/2 - 20, 520), // Increased gap below desc
            };
            contentView.Add(shoppingIcon);
            var shoppingTitle = new TextLabel
            {
                Text = "SHOPPING LIST",
                PointSize = 10.0f,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width/2 - 80, 570), // Increased gap below shopping icon
                Size2D = new Size2D(160, 30),
                HorizontalAlignment = HorizontalAlignment.Center,
                FontStyle = new PropertyMap().contentView.Add("weight", new PropertyValue("bold"))
            };
            contentView.Add(shoppingTitle);

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
            int shoppingListStartY = 620; // Increased gap below shopping title
            for (int i=0; i<shopping.Length; i++)
            {
                var item = new TextLabel
                {
                    Text = "• " + shopping[i],
                    PointSize = 10.0f,
                    PixelSize = 22,
                    TextColor = Color.Black,
                    Position2D = new Position2D(40, shoppingListStartY + i*48), // Increased line spacing
                    Size2D = new Size2D(window.Size.Width-80, 48),
                    MultiLine = true,
                    Ellipsis = false // Prevent '...'
                };
                contentView.Add(item);
            }

            // Preparation Title
            var prepIcon = new ImageView
            {
                ResourceUrl = "icon.png",
                Size2D = new Size2D(40, 40),
                Position2D = new Position2D(window.Size.Width/2 - 20, 1050), // Increased gap below shopping list
            };
            contentView.Add(prepIcon);
            var prepTitle = new TextLabel
            {
                Text = "PREPARATION",
                PointSize = 16.0f,
                PixelSize = 30,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width/2 - 120, 1100), // Increased gap below prep icon
                Size2D = new Size2D(240, 50),
                HorizontalAlignment = HorizontalAlignment.Center,
                MultiLine = true,
                Ellipsis = false,
                FontStyle = new PropertyMap().contentView.Add("weight", new PropertyValue("bold"))
            };
            contentView.Add(prepTitle);

            string[] steps = new string[] {
                "Preheat oven to 350 degrees F. Let roast stand at room temperature for 1 hour.",
                "In a small saucepan over medium-high heat, boil balsamic vinegar until it reduces to 1/4 cup, approximately 3 minutes. Remove from heat and set aside.",
                "Finely mince the parsley. Mix together with the minced garlic, 1/4 teaspoon salt, and a generous amount of pepper. Using the tip of a sharp knife, bore 7 to 10 narrow holes, each about 1 1/2" deep, in the rib roast. Fill the holes with the parsley-garlic mixture. Spread any remaining mixture over the surface of the roast. Sprinkle all sides of the meat with salt and pepper.",
                "After slicing the roast, add any accumulated meat juices to the balsamic sauce. Serve the meat slices on warmed plates with balsamic sauce on the side."
            };
            int prepStepsStartY = 1160; // Increased gap below prep title
            for (int i=0; i<steps.Length; i++)
            {
                var step = new TextLabel
                {
                    Text = "✔ " + steps[i],
                    PointSize = 8.0f,
                    TextColor = Color.Black,
                    Position2D = new Position2D(40, prepStepsStartY + i*58), // Increased line spacing
                    Size2D = new Size2D(window.Size.Width-80, 58),
                    MultiLine = true
                };
                contentView.Add(step);
            }

            // Comments Title
            var commentIcon = new ImageView
            {
                ResourceUrl = "icon.png",
                Size2D = new Size2D(40, 40),
                Position2D = new Position2D(window.Size.Width/2 - 20, 1400), // Increased gap below prep steps
            };
            contentView.Add(commentIcon);
            var commentTitle = new TextLabel
            {
                Text = "COMMENTS",
                PointSize = 16.0f,
                PixelSize = 30,
                TextColor = new Color(0, 0.5f, 1, 1),
                Position2D = new Position2D(window.Size.Width/2 - 120, 1450), // Increased gap below comment icon
                Size2D = new Size2D(240, 50),
                HorizontalAlignment = HorizontalAlignment.Center,
                MultiLine = true,
                Ellipsis = false,
                FontStyle = new PropertyMap().contentView.Add("weight", new PropertyValue("bold"))
            };
            contentView.Add(commentTitle);

            // Comments
            var comments = new List<(string, string, string, string, int)>
            {
                ("TOM KLEIN", "This prime rib roast was amazing!!!", "7.01.2017", "★☆☆☆☆", 1),
                ("SALLY PARKER", "I was amazed at how little preparation this took. Just rub on the herbs and butter, let it sit for a few hours and you have an amazing piece of meat!", "7.01.2017", "★★★★☆", 2)
            };
            int commentsStartY = 1510; // Increased gap below comment title
            for (int i=0; i<comments.Count; i++)
            {
                var (name, comment, date, stars, avatar) = comments[i];
                var y = commentsStartY + i*110; // Increased spacing between comments
                var avatarLabel = new TextLabel
                {
                    Text = avatar == 1 ? "👤" : "👩",
                    PointSize = 14.0f,
                    Position2D = new Position2D(30, y),
                    Size2D = new Size2D(40, 40)
                };
                contentView.Add(avatarLabel);
                var nameLabel = new TextLabel
                {
                    Text = name,
                    PointSize = 8.0f,
                    TextColor = Color.Black,
                    Position2D = new Position2D(80, y),
                    Size2D = new Size2D(180, 20),
                    FontStyle = new PropertyMap().contentView.Add("weight", new PropertyValue("bold"))
                };
                contentView.Add(nameLabel);
                var dateLabel = new TextLabel
                {
                    Text = date,
                    PointSize = 8.0f,
                    TextColor = Color.Gray,
                    Position2D = new Position2D(270, y),
                    Size2D = new Size2D(120, 20)
                };
                contentView.Add(dateLabel);
                var starLabel = new TextLabel
                {
                    Text = stars,
                    PointSize = 10.0f,
                    TextColor = new Color(1, 0.8f, 0, 1),
                    Position2D = new Position2D(80, y+20),
                    Size2D = new Size2D(100, 20)
                };
                contentView.Add(starLabel);
                var commentLabel = new TextLabel
                {
                    Text = comment,
                    PointSize = 8.0f,
                    TextColor = Color.Black,
                    Position2D = new Position2D(80, y+40),
                    Size2D = new Size2D(window.Size.Width-120, 40),
                    MultiLine = true
                };
                contentView.Add(commentLabel);
            }

            // Comment Input
            var commentInput = new TextField
            {
                PlaceholderText = "Type your comment here...",
                Position2D = new Position2D(30, 1750), // Increased gap below comments
                Size2D = new Size2D(window.Size.Width-80, 40),
                BackgroundColor = new Color(0.95f, 0.95f, 0.95f, 1),
                PointSize = 8.0f
            };
            contentView.Add(commentInput);
            var sendIcon = new ImageView
            {
                ResourceUrl = "icon.png",
                Size2D = new Size2D(40, 40),
                Position2D = new Position2D(window.Size.Width-60, 1750), // Align with comment input
            };
            contentView.Add(sendIcon);
        }
    }
}
