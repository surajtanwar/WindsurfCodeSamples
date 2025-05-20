using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class MenuPage : View
    {
        public MenuPage()
        {
            // Reference design size
            float refWidth = 375.0f;
            float refHeight = 667.0f;

            // Set up the menu root view
            this.Size = new Size(refWidth, refHeight);
            this.BackgroundColor = Color.White;
            this.PositionUsesPivotPoint = true;
            this.Position = new Position(0, 0);

            // Red rectangle background
            var rectangle = new View
            {
                Size = new Size(320, 667),
                Position = new Position(-1, 0),
                BackgroundColor = new Color(0.92f, 0.34f, 0.34f, 1.0f), // #eb5757
                PositionUsesPivotPoint = true,
            };
            this.Add(rectangle);

            // Menu button (btn-menu0.svg)
            var menuBtn = new ImageView
            {
                ResourceUrl = "res/images/menu/btn-menu0.svg",
                Size = new Size(24, 18),
                Position = new Position(340, 10),
                PositionUsesPivotPoint = true,
            };
            this.Add(menuBtn);

            // Line (white, rotated)
            var line = new View
            {
                Size = new Size(30, 5),
                Position = new Position(16, 68),
                BackgroundColor = Color.White,
                PositionUsesPivotPoint = true,
                Orientation = new Rotation(new Radian((float)(System.Math.PI / 2)), Vector3.ZAxis),
            };
            this.Add(line);

            // Menu items
            var menuItems = new TextLabel
            {
                Text = "Popular recipes\nsaved recipes\nshopping list\nsettings",
                TextColor = Color.White,
                PointSize = 20.0f,
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("500")),
                Position = new Position(30, 71),
                PositionUsesPivotPoint = true,
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
            };
            this.Add(menuItems);

            // Profile name
            var profileName = new TextLabel
            {
                Text = "harry truman",
                TextColor = Color.White,
                PointSize = 20.0f,
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("500")),
                Position = new Position(30, 616),
                PositionUsesPivotPoint = true,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
            };
            this.Add(profileName);

            // Profile ellipse image
            var ellipse = new ImageView
            {
                ResourceUrl = "res/images/menu/Ellipse.png",
                Size = new Size(46, 46),
                Position = new Position(29, 552),
                PositionUsesPivotPoint = true,
                CornerRadius = 23.0f,
            };
            this.Add(ellipse);
        }
    }
}
