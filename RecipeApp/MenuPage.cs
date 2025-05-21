using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;

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
                Position = new Position(0, 0),
                BackgroundColor = new Color(0.92f, 0.34f, 0.34f, 1.0f), // #EB5757
                PositionUsesPivotPoint = false,
            };
            this.Add(rectangle);

            // Menu button (btn-menu0.svg)
            var menuBtn = new ImageView
            {
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/menu/btn-menu0.svg",
                Size = new Size(ScaleX(24), ScaleY(18)),
                Position = new Position(ScaleX(340), ScaleY(10)), // Inside the rectangle
                PositionUsesPivotPoint = false,
            };
            this.Add(menuBtn);

            // Menu items text
            // Individual menu items as separate TextLabels
            var menuItem1 = new TextLabel
            {
                Text = "POPULAR RECIPES",
                TextColor = Color.White,
                PointSize = 12.0f,
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold")),
                Position = new Position(ScaleX(30), ScaleY(71)),
                PositionUsesPivotPoint = false,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
                EnableMarkup = false,
            };
            this.Add(menuItem1);
            menuItem1.TouchEvent += (s, e) => {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    NavigationHandler.Instance.Show(new RecipeListPage());
                }
                return false;
            };

            var menuItem2 = new TextLabel
            {
                Text = "SAVED RECIPES",
                TextColor = Color.White,
                PointSize = 12.0f,
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold")),
                Position = new Position(ScaleX(30), ScaleY(111)),
                PositionUsesPivotPoint = false,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
                EnableMarkup = false,
            };
            this.Add(menuItem2);

            var menuItem3 = new TextLabel
            {
                Text = "SHOPPING LIST",
                TextColor = Color.White,
                PointSize = 12.0f,
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold")),
                Position = new Position(ScaleX(30), ScaleY(151)),
                PositionUsesPivotPoint = false,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
                EnableMarkup = false,
            };
            this.Add(menuItem3);

            var menuItem4 = new TextLabel
            {
                Text = "SETTINGS",
                TextColor = Color.White,
                PointSize = 12.0f,
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold")),
                Position = new Position(ScaleX(30), ScaleY(191)),
                PositionUsesPivotPoint = false,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
                EnableMarkup = false,
            };
            this.Add(menuItem4);

            // Profile name
            var profileName = new TextLabel
            {
                Text = "HARRY TRUMAN", // Already uppercase
                TextColor = Color.White,
                PointSize = 11.0f,
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("bold")),
                Position = new Position(ScaleX(30), ScaleY(616)), // Inside the rectangle
                PositionUsesPivotPoint = false,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
            };
            this.Add(profileName);

            // Profile ellipse image
            var ellipse = new ImageView
            {
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/menu/ellipse0.png",
                Size = new Size(ScaleX(46), ScaleY(46)),
                Position = new Position(ScaleX(29), ScaleY(552)), // Inside the rectangle
                PositionUsesPivotPoint = false,
                CornerRadius = ScaleX(23), // Half of width for perfect circle
                FittingMode = FittingModeType.ScaleToFill, // Ensures image covers the ellipse
            };
            this.Add(ellipse);

            // Line (horizontal, white, rotated 90deg)
            var line = new View
            {
                Size = new Size(ScaleX(30), ScaleY(5)),
                Position = new Position(ScaleX(5), ScaleY(80)),
                BackgroundColor = Color.White,
                PositionUsesPivotPoint = false,
                Orientation = new Rotation(new Radian((float)(System.Math.PI / 2)), Vector3.ZAxis),
                CornerRadius = ScaleY(2.5f),
            };
            this.Add(line);
        }
    }
}
