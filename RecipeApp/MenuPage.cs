using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class MenuPage : View
    {
        public MenuPage()
        {
            // Reference design size (CSS: 375x667)
            float refWidth = 375.0f;
            float refHeight = 667.0f;

            // Get the actual screen size
            var screenSize = Window.Instance.Size;
            float actualWidth = screenSize.Width;
            float actualHeight = screenSize.Height;

            // Root view fills the screen
            this.Size = new Size(actualWidth, actualHeight);
            this.BackgroundColor = Color.White;
            this.PositionUsesPivotPoint = false;
            this.Position = new Position(0, 0);

            // Helper function for scaling
            float ScaleX(float x) => x / refWidth * actualWidth;
            float ScaleY(float y) => y / refHeight * actualHeight;

            // Red rectangle background (left side)
            var rectangle = new View
            {
                Size = new Size(ScaleX(320), actualHeight),
                Position = new Position(ScaleX(-1), 0),
                BackgroundColor = new Color(0.92f, 0.34f, 0.34f, 1.0f), // #EB5757
                PositionUsesPivotPoint = false,
            };
            this.Add(rectangle);

            // Menu button (btn-menu0.svg)
            var menuBtn = new ImageView
            {
                ResourceUrl = "res/images/menu/btn-menu0.svg",
                Size = new Size(ScaleX(24), ScaleY(18)),
                Position = new Position(ScaleX(340), ScaleY(10)),
                PositionUsesPivotPoint = false,
            };
            this.Add(menuBtn);

            // Menu items text
            var menuItems = new TextLabel
            {
                Text = "POPULAR RECIPES\nSAVED RECIPES\nSHOPPING LIST\nSETTINGS", // Already uppercase
                TextColor = Color.White,
                PointSize = 38.0f, // 20/375*720 = 38
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold")), // Use bold for 500 weight
                Position = new Position(58, 136), // 30/375*720 = 58, 71/667*1280 = 136
                PositionUsesPivotPoint = false,
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
                EnableMarkup = false,
            };
            this.Add(menuItems);

            // Profile name
            var profileName = new TextLabel
            {
                Text = "HARRY TRUMAN", // Already uppercase
                TextColor = Color.White,
                PointSize = ScaleY(20),
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold")),
                Position = new Position(ScaleX(30), ScaleY(616)),
                PositionUsesPivotPoint = false,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
            };
            this.Add(profileName);

            // Profile ellipse image
            var ellipse = new ImageView
            {
                ResourceUrl = "res/images/menu/ellipse0.png",
                Size = new Size(88, 88), // 46/375*720 = 88
                Position = new Position(56, 1060), // 29/375*720 = 56, 552/667*1280 = 1060
                PositionUsesPivotPoint = false,
                CornerRadius = 44.0f, // Half of width/height for perfect circle
                FittingMode = FittingModeType.ScaleToFill, // Ensures image covers the ellipse
            };
            this.Add(ellipse);

            // Line (horizontal, white, rotated 90deg)
            // White horizontal line (matches .line CSS)
            var line = new View
            {
                Size = new Size(ScaleX(30), ScaleY(5)),
                Position = new Position(ScaleX(16), ScaleY(68)),
                BackgroundColor = Color.White,
                PositionUsesPivotPoint = false,
                Orientation = new Rotation(new Radian((float)(System.Math.PI / 2)), Vector3.ZAxis),
                CornerRadius = ScaleY(2.5f),
            };

            this.Add(line);
        }
    }
}
