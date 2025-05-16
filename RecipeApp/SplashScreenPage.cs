using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class SplashScreenPage : View
    {
        public SplashScreenPage()
        {
            Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height);
            BackgroundColor = Color.White;

            var logo = new ImageView
            {
                ResourceUrl = "splash_logo.png", // Place a logo image in project directory
                Size2D = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center
            };
            Add(logo);

            var label = new TextLabel
            {
                Text = "Recipe App",
                PointSize = 16.0f,
                TextColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Position = new Position(0, 150)
            };
            Add(label);
        }
    }
}
