using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class MenuPage : View
    {
        public MenuPage()
        {
            // Reference design size (CSS: 375x667, now scaled to 720x1280)
            float refWidth = 720.0f;
            float refHeight = 1280.0f;

            // Root view fills the screen
            this.Size = new Size(refWidth, refHeight);
            this.BackgroundColor = Color.White;
            this.PositionUsesPivotPoint = false;
            this.Position = new Position(0, 0);

            // Red rectangle background (left side)
            var rectangle = new View
            {
                Size = new Size(614, 1280), // 320/375*720 = 614
                Position = new Position(-2, 0), // -1/375*720 = -2
                BackgroundColor = new Color(0.92f, 0.34f, 0.34f, 1.0f), // #EB5757
                PositionUsesPivotPoint = false,
            };
            this.Add(rectangle);

            // Menu button (btn-menu0.svg)
            var menuBtn = new ImageView
            {
                ResourceUrl = "res/images/menu/btn-menu0.svg",
                Size = new Size(46, 31), // 24/375*720 = 46, 18/667*1280 = 31
                Position = new Position(653, 19), // 340/375*720 = 653, 10/667*1280 = 19
                PositionUsesPivotPoint = false,
            };
            this.Add(menuBtn);

            // Menu items text
            var menuItems = new TextLabel
            {
                Text = "POPULAR RECIPES\nSAVED RECIPES\nSHOPPING LIST\nSETTINGS",
                TextColor = Color.White,
                PointSize = 38.0f, // 20/375*720 = 38
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("500")),
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
                Text = "HARRY TRUMAN",
                TextColor = Color.White,
                PointSize = 38.0f, // 20/375*720 = 38
                FontFamily = "Roboto Medium",
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("500")),
                Position = new Position(58, 1183), // 30/375*720 = 58, 616/667*1280 = 1183
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
                CornerRadius = 44.0f,
            };
            this.Add(ellipse);

            // Line (horizontal, white, rotated 90deg)
            var line = new View
            {
                Size = new Size(57, 10), // width: 30/375*720 = 57, height: 5/375*720 = 10
                Position = new Position(31, 130), // left: 16/375*720 = 31, top: 68/667*1280 = 130
                BackgroundColor = Color.White,
                PositionUsesPivotPoint = false,
                Orientation = new Rotation(new Radian((float)(System.Math.PI / 2)), Vector3.ZAxis),
                CornerRadius = 5.0f,
            };
            this.Add(line);
        }
    }
}
