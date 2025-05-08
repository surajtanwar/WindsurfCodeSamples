using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TizenNUILoginApp
{
    public class RecipeDetailsPage : ContentPage
    {
        private ScrollableBase scrollView;
        private View contentContainer;
        private TextLabel titleLabel;
        private ImageView recipeImage;
        private TextLabel descriptionLabel;
        private TextLabel ingredientsLabel;
        private TextLabel instructionsLabel;

        public RecipeDetailsPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            BackgroundColor = new Color(0.98f, 0.98f, 0.98f, 1.0f);

            // Create main scroll view
            scrollView = new ScrollableBase
            {
                Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height),
                ScrollingDirection = ScrollableBase.Direction.Vertical
            };

            // Create content container
            contentContainer = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Top
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Padding = new Extents(20, 20, 20, 20)
            };

            // Recipe Image
            recipeImage = new ImageView
            {
                ResourceUrl = "recipe-placeholder.jpg",
                Size = new Size(Window.Instance.Size.Width - 40, 300),
                CornerRadius = 15.0f
            };

            // Title
            titleLabel = new TextLabel
            {
                Text = "Delicious Pasta Carbonara",
                PointSize = 24,
                FontWeight = "Bold",
                TextColor = Color.Black,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(0, 0, 20, 10)
            };

            // Description
            descriptionLabel = new TextLabel
            {
                Text = "A classic Italian pasta dish made with eggs, cheese, pancetta, and black pepper. Rich, creamy, and absolutely delicious!",
                PointSize = 16,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(0, 0, 0, 20)
            };

            // Ingredients Section
            ingredientsLabel = CreateSectionLabel("Ingredients");
            var ingredientsList = new TextLabel
            {
                Text = "• 1 pound spaghetti\n• 4 large eggs\n• 1 cup freshly grated Pecorino Romano\n• 1 cup freshly grated Parmigiano-Reggiano\n• 4 ounces pancetta, diced\n• 4 cloves garlic, minced\n• Salt and freshly ground black pepper",
                PointSize = 16,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(0, 0, 0, 20)
            };

            // Instructions Section
            instructionsLabel = CreateSectionLabel("Instructions");
            var instructionsList = new TextLabel
            {
                Text = "1. Bring a large pot of salted water to boil\n2. Cook pasta according to package directions\n3. Meanwhile, in a large bowl, whisk together eggs and cheese\n4. Cook pancetta until crispy\n5. Add garlic to pancetta and cook until fragrant\n6. Combine pasta with egg mixture and pancetta\n7. Season with salt and pepper\n8. Serve immediately with extra cheese",
                PointSize = 16,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent
            };

            // Add all elements to the container
            contentContainer.Add(recipeImage);
            contentContainer.Add(titleLabel);
            contentContainer.Add(descriptionLabel);
            contentContainer.Add(ingredientsLabel);
            contentContainer.Add(ingredientsList);
            contentContainer.Add(instructionsLabel);
            contentContainer.Add(instructionsList);

            // Add container to scroll view
            scrollView.Add(contentContainer);
            Add(scrollView);
        }

        private TextLabel CreateSectionLabel(string text)
        {
            return new TextLabel
            {
                Text = text,
                PointSize = 20,
                FontWeight = "Bold",
                TextColor = Color.Black,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(0, 0, 20, 10)
            };
        }
    }
}
