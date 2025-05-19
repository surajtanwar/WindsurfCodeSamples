using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;

namespace RecipeApp
{
    public class RecipeListPage : View
    {
        public RecipeListPage()
        {
            // Reference design size
            float refWidth = 375.0f;
            float refHeight = 667.0f;
            float screenWidth = Window.Instance.WindowSize.Width;
            float screenHeight = Window.Instance.WindowSize.Height;
            float scaleX = screenWidth / refWidth;
            float scaleY = screenHeight / refHeight;
            float scale = (scaleX + scaleY) / 2.0f;

            // Set the main view size and background
            Size2D = new Size2D((int)screenWidth, (int)screenHeight);
            BackgroundColor = Color.White;

            // Menu button (top-left)
            var btnMenu = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/btn-menu0.svg",
                Size2D = new Size2D((int)(24 * scaleX), (int)(18 * scaleY)),
                Position = new Position((int)(20 * scaleX), (int)(10 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(btnMenu);

            // Search button (top-right)
            var btnSearch = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/btn-search0.svg",
                Size2D = new Size2D((int)(23.83f * scaleX), (int)(23.83f * scaleY)),
                Position = new Position((int)(screenWidth - (23.83f + 20.17f) * scaleX), (int)(10 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(btnSearch);

            // POPULAR RECIPES title (centered top)
            var popularRecipes = new TextLabel
            {
                Text = "POPULAR RECIPES",
                PointSize = 11, // decreased by 3 and rounded
                FontFamily = "Roboto-Bold",
                TextColor = new Color(0.92f, 0.34f, 0.34f, 1.0f), // #eb5757
                HorizontalAlignment = HorizontalAlignment.Center,
                Position = new Position(0, (int)(10 * scaleY)),
                Size2D = new Size2D((int)screenWidth, (int)(30 * scaleY))
            };
            Add(popularRecipes);

            // Category labels
            float catY = 84 * scaleY;
            float appetizersX = (screenWidth / 2) - (122.5f * scaleX);
            float entreesX = (screenWidth / 2) - (17.5f * scaleX);
            float dessertX = (screenWidth / 2) + (67.5f * scaleX);

            var appetizers = new TextLabel
            {
                Text = "APPETIZERS",
                PointSize = 7, // decreased by 3 and rounded
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.45f, 0.45f, 0.45f, 1.0f), // #737373
                Position = new Position((int)appetizersX, (int)catY),
                Size2D = new Size2D((int)(100 * scaleX), (int)(20 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(appetizers);

            var entrees = new TextLabel
            {
                Text = "ENTREES",
                PointSize = 7, // decreased by 3 and rounded
                FontFamily = "Roboto-Medium",
                TextColor = Color.Black,
                Position = new Position((int)entreesX, (int)catY),
                Size2D = new Size2D((int)(100 * scaleX), (int)(20 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(entrees);

            var dessert = new TextLabel
            {
                Text = "DESSERT",
                PointSize = 7, // decreased by 3 and rounded
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.45f, 0.45f, 0.45f, 1.0f),
                Position = new Position((int)dessertX, (int)catY),
                Size2D = new Size2D((int)(100 * scaleX), (int)(20 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(dessert);

            // Category underline (under ENTREES)
            var underline = new View
            {
                BackgroundColor = Color.Black,
                Size2D = new Size2D((int)(54 * scaleX), 2),
                Position = new Position((int)((screenWidth / 2) - (16.5f * scaleX)), (int)(106 * scaleY)),
            };
            Add(underline);

            // Carousel for maskGroupLeft, maskGroupRight, and recipeRect
            var carouselImages = new[]
            {
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group1.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group0.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/rectangle0.png"
            };
            int carouselIndex = 0;
            var carouselView = new ImageView
            {
                ResourceUrl = carouselImages[carouselIndex],
                Size2D = new Size2D((int)(221 * scaleX), (int)(221 * scaleY)),
                Position = new Position((int)(77 * scaleX), (int)(126 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(carouselView);

            // Left button
            var leftBtn = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/mask-group0.svg",
                Size2D = new Size2D((int)(30 * scaleX), (int)(30 * scaleY)),
                Position = new Position((int)(30 * scaleX), (int)(226 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(leftBtn);

            // Right button
            var rightBtn = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/mask-group1.svg",
                Size2D = new Size2D((int)(30 * scaleX), (int)(30 * scaleY)),
                Position = new Position((int)(320 * scaleX), (int)(226 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(rightBtn);

            // Button logic for carousel
            leftBtn.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    carouselIndex = (carouselIndex + carouselImages.Length - 1) % carouselImages.Length;
                    carouselView.ResourceUrl = carouselImages[carouselIndex];
                }
                return false;
            };
            rightBtn.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    carouselIndex = (carouselIndex + 1) % carouselImages.Length;
                    carouselView.ResourceUrl = carouselImages[carouselIndex];
                }
                return false;
            };

            // Heart button (top right of rectangle)
            var heartBtn = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/button-heart0.svg",
                Size2D = new Size2D((int)(20 * scaleX), (int)(18 * scaleY)),
                Position = new Position((int)(268 * scaleX), (int)(137 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(heartBtn);

            // 5 Stars (centered over rectangle)
            float starsStartX = (float)(123 * scaleX);
            float starY = (float)(356 * scaleY);
            float starSpacing = 21 * scaleX;
            for (int i = 0; i < 5; i++)
            {
                var star = new ImageView
                {
                    ResourceUrl = Application.Current.DirectoryInfo.Resource + $"images/home/star{i}.svg",
                    Size2D = new Size2D((int)(16 * scaleX), (int)(16 * scaleY)),
                    Position = new Position((int)(starsStartX + i * starSpacing), (int)starY),
                    PositionUsesPivotPoint = false
                };
                Add(star);
            }

            // Recipe title
            var recipeTitle = new TextLabel
            {
                Text = "Prime Rib Roast",
                PointSize = 11, // decreased by 3 and rounded
                FontFamily = "Roboto-Bold",
                TextColor = new Color(0.10f, 0.35f, 0.49f, 1.0f), // #19597d
                Position = new Position((int)(123 * scaleX), (int)(390 * scaleY)),
                Size2D = new Size2D((int)(200 * scaleX), (int)(30 * scaleY)),
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
                    ResourceUrl = Application.Current.DirectoryInfo.Resource + $"images/home/{icons[i]}",
                    Size2D = new Size2D((int)(19 * scaleX), (int)(18 * scaleY)),
                    Position = new Position((int)(iconPositions[i] * scaleX), (int)(427 * scaleY)),
                    PositionUsesPivotPoint = false
                };
                Add(icon);
            }
            // 5HR text
            var timeLabel = new TextLabel
            {
                Text = "5HR",
                PointSize = 8, // decreased by 3 and rounded
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position((int)(103 * scaleX), (int)(427 * scaleY)),
                Size2D = new Size2D((int)(40 * scaleX), (int)(23 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(timeLabel);
            // 685 text
            var calLabel = new TextLabel
            {
                Text = "685",
                PointSize = 8, // decreased by 3 and rounded
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position((int)(189 * scaleX), (int)(427 * scaleY)),
                Size2D = new Size2D((int)(40 * scaleX), (int)(23 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(calLabel);
            // 107 text
            var likeLabel = new TextLabel
            {
                Text = "107",
                PointSize = 8, // decreased by 3 and rounded
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position((int)(268 * scaleX), (int)(427 * scaleY)),
                Size2D = new Size2D((int)(40 * scaleX), (int)(23 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(likeLabel);

            // Description text
            var descLabel = new TextLabel
            {
                Text = "The Prime Rib Roast is a classic and tender cut of beef taken from the rib primal cut. Learn how to make the perfect prime rib roast to serve your family and friends. Check out What’s Cooking America’s award-winning Classic Prime Rib Roast recipe and photo tutorial to help you make the Perfect Prime Rib Roast.",
                PointSize = 8, // decreased by 3 and rounded
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.46f, 0.46f, 0.46f, 1.0f), // #757575
                Position = new Position((int)(21 * scaleX), (int)(462 * scaleY)),
                Size2D = new Size2D((int)(335 * scaleX), (int)(200 * scaleY)), // Further increased height for more lines
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            descLabel.Ellipsis = false; // Explicitly disable ellipsis
            // Remove ellipsis if set elsewhere (default is none for TextLabel)
            // If needed, descLabel.Ellipsis = false; after creation
            // Add(descLabel) remains the same.
            Add(descLabel);
        }
    }
}
