using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;

namespace RecipeApp
{
    public class RecipeListPage : View
    {
        private enum Category { Appetizers, Entrees, Dessert }
        private Category selectedCategory = Category.Entrees;
        private TextLabel appetizers, entrees, dessert;
        private View underline;
        private ImageView carouselView, leftBtn, rightBtn, heartBtn;
        private TextLabel recipeTitle, timeLabel, calLabel, likeLabel, descLabel;
        private ImageView[] starViews = new ImageView[5];
        private ImageView[] iconViews = new ImageView[3];
        private int carouselIndex = 0;
        private string[][] carouselImages = new string[3][];
        private string[] recipeTitles = new string[3];
        private string[] recipeDescriptions = new string[3];
        private string[][] recipeIcons = new string[3][];
        private string[][] recipeIconLabels = new string[3][];
        private float scaleX, scaleY, screenWidth, screenHeight;
        private float[] iconPositions = new float[3];

        private void UpdateCategory(Category category)
        {
            selectedCategory = category;
            // Visual feedback for labels
            appetizers.TextColor = (category == Category.Appetizers) ? Color.Black : new Color(0.45f, 0.45f, 0.45f, 1.0f);
            entrees.TextColor = (category == Category.Entrees) ? Color.Black : new Color(0.45f, 0.45f, 0.45f, 1.0f);
            dessert.TextColor = (category == Category.Dessert) ? Color.Black : new Color(0.45f, 0.45f, 0.45f, 1.0f);

            // Move underline
            float entreesX = (screenWidth / 2) - (17.5f * scaleX);
            float appetizersX = (screenWidth / 2) - (122.5f * scaleX);
            float dessertX = (screenWidth / 2) + (67.5f * scaleX);
            float underlineX = category == Category.Entrees ? entreesX + (100 * scaleX) / 2 - (54 * scaleX) / 2 :
                               category == Category.Appetizers ? appetizersX + (100 * scaleX) / 2 - (54 * scaleX) / 2 :
                               dessertX + (100 * scaleX) / 2 - (54 * scaleX) / 2;
            underline.Position = new Position((int)underlineX, (int)(106 * scaleY));

            // Update carousel images, title, description, and icons
            carouselIndex = 0;
            carouselView.ResourceUrl = carouselImages[(int)category][carouselIndex];
            recipeTitle.Text = recipeTitles[(int)category];
            descLabel.Text = recipeDescriptions[(int)category];
            for (int i = 0; i < 3; i++)
            {
                iconViews[i].ResourceUrl = recipeIcons[(int)category][i];
                iconViews[i].Position = new Position((int)(iconPositions[i] * scaleX), (int)(427 * scaleY));
            }
            timeLabel.Text = recipeIconLabels[(int)category][0];
            calLabel.Text = recipeIconLabels[(int)category][1];
            likeLabel.Text = recipeIconLabels[(int)category][2];
        }

        public RecipeListPage()
        {
            // Reference design size
            float refWidth = 375.0f;
            float refHeight = 667.0f;
            screenWidth = Window.Instance.WindowSize.Width;
            screenHeight = Window.Instance.WindowSize.Height;
            scaleX = screenWidth / refWidth;
            scaleY = screenHeight / refHeight;
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
            float catLabelWidth = 100 * scaleX;
            float catSpacing = 22.5f * scaleX;
            float centerX = screenWidth / 2;
            float appetizersX = centerX - catLabelWidth - catSpacing;
            float entreesX = centerX - (catLabelWidth / 2);
            float dessertX = centerX + catLabelWidth / 2 + catSpacing - catLabelWidth;


            appetizers = new TextLabel
            {
                Text = "APPETIZERS",
                PointSize = 7,
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.45f, 0.45f, 0.45f, 1.0f),
                Position = new Position((int)appetizersX, (int)catY),
                Size2D = new Size2D((int)(100 * scaleX), (int)(20 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(appetizers);
            entrees = new TextLabel
            {
                Text = "ENTREES",
                PointSize = 7,
                FontFamily = "Roboto-Medium",
                TextColor = Color.Black,
                Position = new Position((int)entreesX, (int)catY),
                Size2D = new Size2D((int)(100 * scaleX), (int)(20 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(entrees);
            dessert = new TextLabel
            {
                Text = "DESSERT",
                PointSize = 7,
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.45f, 0.45f, 0.45f, 1.0f),
                Position = new Position((int)dessertX, (int)catY),
                Size2D = new Size2D((int)(100 * scaleX), (int)(20 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(dessert);

            // Add touch handlers for category switching
            appetizers.TouchEvent += (s, e) => { if (e.Touch.GetState(0) == PointStateType.Up) UpdateCategory(Category.Appetizers); return false; };
            entrees.TouchEvent += (s, e) => { if (e.Touch.GetState(0) == PointStateType.Up) UpdateCategory(Category.Entrees); return false; };
            dessert.TouchEvent += (s, e) => { if (e.Touch.GetState(0) == PointStateType.Up) UpdateCategory(Category.Dessert); return false; };


            // Category underline (under ENTREES)
            underline = new View
            {
                BackgroundColor = Color.Black,
                Size2D = new Size2D((int)(54 * scaleX), 2),
                Position = new Position((int)(centerX - (54 * scaleX) / 2), (int)(106 * scaleY)),
            };
            Add(underline);

            // Carousel for maskGroupLeft, maskGroupRight, and recipeRect
            carouselImages[0] = new[]
            {
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group1.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group0.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/rectangle0.png"
            };
            carouselImages[1] = new[]
            {
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group0.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group1.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/rectangle0.png"
            };
            carouselImages[2] = new[]
            {
                Application.Current.DirectoryInfo.Resource + "images/home/rectangle0.png",
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group1.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/mask-group0.svg"
            };
            recipeTitles[0] = "Bruschetta";
            recipeTitles[1] = "Prime Rib Roast";
            recipeTitles[2] = "Chocolate Cake";
            recipeDescriptions[0] = "Classic Italian appetizer with tomatoes, garlic, and basil on toasted bread.";
            recipeDescriptions[1] = "The Prime Rib Roast is a classic and tender cut of beef taken from the rib primal cut. Learn how to make the perfect prime rib roast to serve your family and friends. Check out What’s Cooking America’s award-winning Classic Prime Rib Roast recipe and photo tutorial to help you make the Perfect Prime Rib Roast.";
            recipeDescriptions[2] = "Rich, moist chocolate cake layered with creamy chocolate frosting.";
            recipeIcons[0] = new string[] {
                Application.Current.DirectoryInfo.Resource + "images/home/icons0.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/icons1.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/icons2.svg"
            };
            recipeIcons[1] = new string[] {
                Application.Current.DirectoryInfo.Resource + "images/home/icons0.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/icons1.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/icons2.svg"
            };
            recipeIcons[2] = new string[] {
                Application.Current.DirectoryInfo.Resource + "images/home/icons0.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/icons1.svg",
                Application.Current.DirectoryInfo.Resource + "images/home/icons2.svg"
            };
            recipeIconLabels[0] = new string[] { "10M", "150", "24" };
            recipeIconLabels[1] = new string[] { "5HR", "685", "107" };
            recipeIconLabels[2] = new string[] { "45M", "420", "300" };
            iconPositions = new float[] { 77, 166, 241 };
            carouselIndex = 0;
            carouselView = new ImageView
            {
                ResourceUrl = carouselImages[(int)selectedCategory][carouselIndex],
                Size2D = new Size2D((int)(221 * scaleX), (int)(221 * scaleY)),
                Position = new Position((int)(centerX - (221 * scaleX) / 2), (int)(126 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(carouselView);

            // Left button
            leftBtn = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/mask-group0.svg",
                Size2D = new Size2D((int)(30 * scaleX), (int)(30 * scaleY)),
                Position = new Position((int)(centerX - (221 * scaleX) / 2 - 35 * scaleX), (int)(226 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(leftBtn);

            // Right button
            rightBtn = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/mask-group1.svg",
                Size2D = new Size2D((int)(30 * scaleX), (int)(30 * scaleY)),
                Position = new Position((int)(centerX + (221 * scaleX) / 2 + 5 * scaleX), (int)(226 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(rightBtn);

            // Carousel button logic
            leftBtn.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    carouselIndex = (carouselIndex + carouselImages[(int)selectedCategory].Length - 1) % carouselImages[(int)selectedCategory].Length;
                    carouselView.ResourceUrl = carouselImages[(int)selectedCategory][carouselIndex];
                }
                return false;
            };
            rightBtn.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    carouselIndex = (carouselIndex + 1) % carouselImages[(int)selectedCategory].Length;
                    carouselView.ResourceUrl = carouselImages[(int)selectedCategory][carouselIndex];
                }
                return false;
            };




            // Heart button (top right of rectangle)
            heartBtn = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/home/button-heart0.svg",
                Size2D = new Size2D((int)(20 * scaleX), (int)(18 * scaleY)),
                Position = new Position((int)(centerX + (221 * scaleX) / 2 - 30 * scaleX), (int)(137 * scaleY)),
                PositionUsesPivotPoint = false
            };
            Add(heartBtn);

            // Recipe title
            recipeTitle = new TextLabel
            {
                Text = recipeTitles[(int)selectedCategory],
                PointSize = 11,
                FontFamily = "Roboto-Bold",
                TextColor = new Color(0.10f, 0.35f, 0.49f, 1.0f),
                Position = new Position((int)(centerX - (200 * scaleX) / 2), (int)(390 * scaleY)),
                Size2D = new Size2D((int)(200 * scaleX), (int)(30 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(recipeTitle);

            // 5 Stars (centered under title)
            float starY = (float)(425 * scaleY);
            float starSpacing = 21 * scaleX;
            float starsWidth = 5 * 16 * scaleX + 4 * starSpacing;
            float starsStartX = centerX - (starsWidth / 2);
            for (int i = 0; i < 5; i++)
            {
                starViews[i] = new ImageView
                {
                    ResourceUrl = Application.Current.DirectoryInfo.Resource + $"images/home/star{i}.svg",
                    Size2D = new Size2D((int)(16 * scaleX), (int)(16 * scaleY)),
                    Position = new Position((int)(starsStartX + i * (16 * scaleX + starSpacing)), (int)starY),
                    PositionUsesPivotPoint = false
                };
                Add(starViews[i]);
            }

            // Recipe info icons and labels (now below stars)
            float iconsTotalWidth = 3 * 19 * scaleX + 2 * 40 * scaleX;
            float iconsStartX = centerX - (iconsTotalWidth / 2);
            float iconsY = (float)(460 * scaleY);
            for (int i = 0; i < 3; i++)
            {
                iconViews[i] = new ImageView
                {
                    ResourceUrl = recipeIcons[(int)selectedCategory][i],
                    Size2D = new Size2D((int)(19 * scaleX), (int)(18 * scaleY)),
                    Position = new Position((int)(iconsStartX + i * (19 * scaleX + 40 * scaleX)), (int)iconsY),
                    PositionUsesPivotPoint = false
                };
                Add(iconViews[i]);
            }
            // 5HR text
            float labelY = (int)(485 * scaleY);
            float labelSpacing = 59 * scaleX;
            float labelsTotalWidth = 3 * 40 * scaleX + 2 * labelSpacing;
            float labelsStartX = centerX - (labelsTotalWidth / 2);
            timeLabel = new TextLabel
            {
                Text = recipeIconLabels[(int)selectedCategory][0],
                PointSize = 8,
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position((int)(labelsStartX), (int)labelY),
                Size2D = new Size2D((int)(40 * scaleX), (int)(23 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(timeLabel);
            calLabel = new TextLabel
            {
                Text = recipeIconLabels[(int)selectedCategory][1],
                PointSize = 8,
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position((int)(labelsStartX + 40 * scaleX + labelSpacing), (int)labelY),
                Size2D = new Size2D((int)(40 * scaleX), (int)(23 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(calLabel);
            likeLabel = new TextLabel
            {
                Text = recipeIconLabels[(int)selectedCategory][2],
                PointSize = 8,
                FontFamily = "Roboto-Regular",
                TextColor = Color.Black,
                Position = new Position((int)(labelsStartX + 2 * (40 * scaleX + labelSpacing)), (int)labelY),
                Size2D = new Size2D((int)(40 * scaleX), (int)(23 * scaleY)),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Add(likeLabel);

            // Description text
            descLabel = new TextLabel
            {
                Text = recipeDescriptions[(int)selectedCategory],
                PointSize = 8,
                FontFamily = "Roboto-Regular",
                TextColor = new Color(0.46f, 0.46f, 0.46f, 1.0f),
                Position = new Position((int)(centerX - (335 * scaleX) / 2), (int)(462 * scaleY)),
                Size2D = new Size2D((int)(335 * scaleX), (int)(200 * scaleY)),
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            descLabel.Ellipsis = false;
            Add(descLabel);
            // Set initial category
            UpdateCategory(selectedCategory);
        }
    }
}
