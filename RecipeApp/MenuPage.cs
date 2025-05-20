using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class MenuPage : View
    {
        public MenuPage()
        {
            // Reference design size
            float refWidth = 720.0f;
            float refHeight = 1280.0f;

            // Set up the menu root view
            this.Size = new Size(refWidth, refHeight);
            this.BackgroundColor = Color.White;
            this.PositionUsesPivotPoint = true;
            this.Position = new Position(0, 0);

            // Red rectangle background (left side)
            var rectangle = new View
            {
                Size = new Size(614, 1280), // 320/375 = 0.853, so 0.853*720 ≈ 614
                Position = new Position(-2, 0), // x: -1/375*720 ≈ -2
                BackgroundColor = new Color(0.92f, 0.34f, 0.34f, 1.0f), // #EB5757
                PositionUsesPivotPoint = true,
            };
            this.Add(rectangle);

            // Menu button (btn-menu0.svg) - top right
            var menuBtn = new ImageView
            {
                ResourceUrl = "res/images/menu/btn-menu0.svg",
                Size = new Size(46, 31), // 24/375*720 ≈ 46, 18/667*1280 ≈ 31
                Position = new Position(653, 19), // 340/375*720 ≈ 653, 10/667*1280 ≈ 19
                PositionUsesPivotPoint = true,
            };
            this.Add(menuBtn);

            // Vertical line (white)
            var line = new View
            {
                Size = new Size(10, 57), // 5/375*720 ≈ 10, 30/667*1280 ≈ 57
                Position = new Position(35, 134), // 16/375*720 ≈ 31, 68/667*1280 ≈ 130
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
                PointSize = 38.0f, // 20/375*720 ≈ 38
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("500")),
                Position = new Position(58, 136), // 30/375*720 ≈ 58, 71/667*1280 ≈ 136
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
                PointSize = 38.0f, // 20/375*720 ≈ 38
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("500")),
                Position = new Position(58, 1183), // 30/375*720 ≈ 58, 616/667*1280 ≈ 1183
                PositionUsesPivotPoint = true,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
            };
            this.Add(profileName);

            // Profile ellipse image
            var ellipse = new ImageView
            {
                ResourceUrl = "res/images/menu/Ellipse.png",
                Size = new Size(88, 88), // 46/375*720 ≈ 88
                Position = new Position(56, 1060), // 29/375*720 ≈ 56, 552/667*1280 ≈ 1060
                PositionUsesPivotPoint = true,
                CornerRadius = 44.0f,
            };
            this.Add(ellipse);
        }
    }
}
