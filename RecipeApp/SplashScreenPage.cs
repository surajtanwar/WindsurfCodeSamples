using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;

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
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/splash/Rectangle.png",
                BackgroundColor = Color.Red,
                Size2D = new Size2D(750, 1334),
                Position = new Position(0, 0),
                PositionUsesPivotPoint = false
            };
            Add(rectangleBg);

            // Group.png overlay (left: 91px, top: 111px)
            var groupOverlay = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/splash/Group.png",
                BackgroundColor = Color.Green,
                Position = new Position(182, 222),
                PositionUsesPivotPoint = false,
                Size2D = new Size2D(386, 320)
            };
            Add(groupOverlay);

            // Group_2.png overlay (left: 93px, top: 365px)
            var group2Overlay = new ImageView
            {
                ResourceUrl = Application.Current.DirectoryInfo.Resource + "images/splash/Group_2.png",
                BackgroundColor = Color.Blue,
                Position = new Position(186, 730),
                PositionUsesPivotPoint = false,
                Size2D = new Size2D(378, 280)
            };
            Add(group2Overlay);
        
        }
    }
}
