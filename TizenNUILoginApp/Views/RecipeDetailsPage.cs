using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TizenNUILoginApp.Views
{
    public class RecipeDetailsPage : ViewBase
    {
        public RecipeDetailsPage()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var window = Window.Instance;
            BackgroundColor = new Color("#FFFFFF");

            var stackLayout = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(20, 20)
                },
                Size = new Size(window.Size.Width, window.Size.Height),
                BackgroundColor = new Color("#FFFFFF")
            };

            var titleLabel = new TextLabel
            {
                Text = "Recipe Details",
                PointSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = new Color("#000000")
            };

            var contentLabel = new TextLabel
            {
                Text = "Welcome to the Recipe Details Page!\nThis is a placeholder for recipe content.",
                PointSize = 16,
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = new Color("#000000")
            };

            stackLayout.Add(titleLabel);
            stackLayout.Add(contentLabel);

            Add(stackLayout);
        }
    }
}
