using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class SplashScreenPage : View
    {
        public SplashScreenPage()
        {
            // Set full window size and white background
            Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height);
            BackgroundColor = Color.White;

            // Rectangle background (375x667px, positioned at 0,0)
            var rectangleBg = new ImageView
            {
                ResourceUrl = "res/images/splash/Rectangle.png",
                BackgroundColor = Color.Red,
                Size2D = new Size2D(375, 667),
                Position = new Position(0, 0),
                PositionUsesPivotPoint = false
            };
            Add(rectangleBg);

            // Group.png overlay (left: 91px, top: 111px)
            var groupOverlay = new ImageView
            {
                ResourceUrl = "res/images/splash/Group.png",
                BackgroundColor = Color.Green,
                Position = new Position(91, 111),
                PositionUsesPivotPoint = false,
                Size2D = new Size2D(193, 160)
            };
            Add(groupOverlay);

            // Group_2.png overlay (left: 93px, top: 365px)
            var group2Overlay = new ImageView
            {
                ResourceUrl = "res/images/splash/Group_2.png",
                BackgroundColor = Color.Blue,
                Position = new Position(93, 365),
                PositionUsesPivotPoint = false,
                Size2D = new Size2D(189, 140)
            };
            Add(group2Overlay);
        
        }
    }
}
