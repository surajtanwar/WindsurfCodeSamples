using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class RecipeListPage : View
    {
        public RecipeListPage()
        {
            // Set the main view size and background
            Size2D = new Size2D(375, 667); // iPhone 8 size for reference
            BackgroundColor = Color.White;

            // Menu button (top-left)
            var btnMenu = new ImageView
            {
                ResourceUrl = "images/home/btn-menu0.svg",
                Size2D = new Size2D(24, 18),
                Position = new Position(20, 10),
                PositionUsesPivotPoint = false
            };
            Add(btnMenu);

            // Search button (top-right)
            var btnSearch = new ImageView
            {
                ResourceUrl = "images/home/btn-search0.svg",
                Size2D = new Size2D(24, 24),
                Position = new Position(331, 10), // 375-24-20 = 331
                PositionUsesPivotPoint = false
            };
            Add(btnSearch);

            // POPULAR RECIPES title (centered top)
            var popularRecipes = new TextLabel
            {
                Text = "POPULAR RECIPES",
                PointSize = 18.0f,
                FontFamily = "Roboto-Bold",
                TextColor = new Color(0.92f, 0.34f, 0.34f, 1.0f), // #eb5757
                HorizontalAlignment = HorizontalAlignment.Center,
                Position = new Position(0, 10),
                Size2D = new Size2D(375, 30)
            };
            Add(popularRecipes);

            // Category labels
            var appetizers = new TextLabel
            {
                Text = "APPETIZERS",
                PointSize = 13.0f,
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.45f, 0.45f, 0.45f, 1.0f), // #737373
                Position = new Position(66, 84),
                Size2D = new Size2D(100, 20),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(appetizers);

            var entrees = new TextLabel
            {
                Text = "ENTREES",
                PointSize = 13.0f,
                FontFamily = "Roboto-Medium",
                TextColor = Color.Black,
                Position = new Position(168, 84),
                Size2D = new Size2D(100, 20),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(entrees);

            var dessert = new TextLabel
            {
                Text = "DESSERT",
                PointSize = 13.0f,
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.45f, 0.45f, 0.45f, 1.0f),
                Position = new Position(259, 84),
                Size2D = new Size2D(100, 20),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(dessert);

            // Category underline (under ENTREES)
            var underline = new View
            {
                Size2D = new Size2D(54, 2),
                BackgroundColor = Color.Black,
                Position = new Position(179, 106),
                PositionUsesPivotPoint = false
            };
            Add(underline);

            // Mask groups (decorative SVGs, left/right)
            var maskGroupLeft = new ImageView
            {
                ResourceUrl = "images/home/mask-group1.svg",
                Position = new Position(-133, 136),
                PositionUsesPivotPoint = false
            };
            Add(maskGroupLeft);

            var maskGroupRight = new ImageView
            {
                ResourceUrl = "images/home/mask-group0.svg",
                Position = new Position(308, 136),
                PositionUsesPivotPoint = false
            };
            Add(maskGroupRight);

            // Main recipe rectangle (center)
            var recipeRect = new ImageView
            {
                ResourceUrl = "images/home/rectangle0.png",
                Size2D = new Size2D(221, 221),
                Position = new Position(77, 126),
                PositionUsesPivotPoint = false
            };
            Add(recipeRect);

            // Heart button (top right of rectangle)
            var heartBtn = new ImageView
            {
                ResourceUrl = "images/home/button-heart0.svg",
                Size2D = new Size2D(20, 18),
                Position = new Position(268, 137),
                PositionUsesPivotPoint = false
            };
            Add(heartBtn);

            // 5 Stars (centered over rectangle)
            for (int i = 0; i < 5; i++)
            {
                var star = new ImageView
                {
                    ResourceUrl = $"images/home/star{i}.svg",
                    Size2D = new Size2D(16, 16),
                    Position = new Position(123 + i * 21, 356),
                    PositionUsesPivotPoint = false
                };
                Add(star);
            }

            // Recipe title
            var recipeTitle = new TextLabel
            {
                Text = "Prime Rib Roast",
                PointSize = 18.0f,
                FontFamily = "Roboto-Bold",
                TextColor = new Color(0.10f, 0.35f, 0.49f, 1.0f), // #19597d
                Position = new Position(123, 390),
                Size2D = new Size2D(200, 30),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(recipeTitle);

            // Recipe info icons and labels
            var icons = new[] { "icons0.svg", "icons1.svg", "icons2.svg" };
            var iconPositions = new[] { 77, 166, 241 };
            for (int i = 0; i < 3; i++)
            {
                var icon = new ImageView
                {
                    ResourceUrl = $"images/home/{icons[i]}",
                    Size2D = new Size2D(19, 18),
                    Position = new Position(iconPositions[i], 427),
                    PositionUsesPivotPoint = false
                };
                Add(icon);
            }
            // 5HR text
            var timeLabel = new TextLabel
            {
                Text = "5HR",
                PointSize = 14.0f,
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position(103, 427),
                Size2D = new Size2D(40, 18),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(timeLabel);
            // 685 text
            var calLabel = new TextLabel
            {
                Text = "685",
                PointSize = 14.0f,
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position(189, 427),
                Size2D = new Size2D(40, 18),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(calLabel);
            // 107 text
            var likeLabel = new TextLabel
            {
                Text = "107",
                PointSize = 14.0f,
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position(268, 427),
                Size2D = new Size2D(40, 18),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(likeLabel);

            // Description text
            var descLabel = new TextLabel
            {
                Text = "The Prime Rib Roast is a classic and tender cut of beef taken from the rib primal cut. Learn how to make the perfect prime rib roast to serve your family and friends. Check out What’s Cooking America’s award-winning Classic Prime Rib Roast recipe and photo tutorial to help you make the Perfect Prime Rib Roast.",
                PointSize = 14.0f,
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.46f, 0.46f, 0.46f, 1.0f), // #757575
                Position = new Position(21, 462),
                Size2D = new Size2D(335, 80),
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(descLabel);
        }
    }
}
