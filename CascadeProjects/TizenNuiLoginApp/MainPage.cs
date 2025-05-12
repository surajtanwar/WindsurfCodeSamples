using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TizenNuiLoginApp
{
    public class MainPage
    {
        public View View { get; private set; }
        private TextField usernameField;
        private TextField passwordField;
        private Button submitButton;

        public MainPage()
        {
            View = new View
            {
                Size = new Size(360, 640),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 20)
                },
                BackgroundColor = Color.White
            };

            usernameField = new TextField
            {
                PlaceholderText = "Username",
                Size = new Size(300, 80),
                PointSize = 12.0f,
                BackgroundColor = new Color(0.95f, 0.95f, 0.95f, 1.0f),
                Margin = new Extents(0, 0, 40, 0)
            };
            passwordField = new TextField
            {
                PlaceholderText = "Password",
                Size = new Size(300, 80),
                PointSize = 12.0f,
                BackgroundColor = new Color(0.95f, 0.95f, 0.95f, 1.0f),
                Margin = new Extents(0, 0, 20, 0)
            };
            passwordField.HiddenInputSettings = new PropertyMap();
            passwordField.HiddenInputSettings.Add("mode", new PropertyValue("password"));
            passwordField.HiddenInputSettings.Add("substituteCharacter", new PropertyValue("*"));
            submitButton = new Button
            {
                Text = "Submit",
                Size = new Size(300, 80),
                PointSize = 12.0f,
                BackgroundColor = new Color(0.2f, 0.6f, 1.0f, 1.0f)
            };
            submitButton.ClickEvent += (s, e) =>
            {
                string username = usernameField.Text;
                string password = passwordField.Text;
                // Handle login logic here
                Window.Instance.Add(new TextLabel
                {
                    Text = $"Welcome, {username}!",
                    PointSize = 10.0f,
                    Position = new Position(30, 500),
                    TextColor = Color.Black
                });
            };

            View.Add(usernameField);
            View.Add(passwordField);
            View.Add(submitButton);
        }
    }
}
