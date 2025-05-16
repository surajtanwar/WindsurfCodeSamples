using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window.Instance.KeyEvent += OnKeyEvent;
            ShowSplashScreen();
        }

        private void ShowSplashScreen()
        {
            // Remove all previous views
            Window.Instance.GetDefaultLayer().RemoveAllChildren();

            // Splash background
            var splashView = new View
            {
                Size = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height),
                BackgroundColor = Color.White,
                Layout = new AbsoluteLayout()
            };

            // Splash image (use splash.jpg if available)
            var splashImage = new ImageView("splash.jpg")
            {
                Size = new Size(300, 300),
                Position = new Position((Window.Instance.WindowSize.Width - 300) / 2, (Window.Instance.WindowSize.Height - 300) / 2)
            };
            splashView.Add(splashImage);

            // App title
            var title = new TextLabel
            {
                Text = "Recipe App",
                PointSize = 18.0f,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Size = new Size(Window.Instance.WindowSize.Width, 80),
                Position = new Position(0, Window.Instance.WindowSize.Height - 120),
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent
            };
            splashView.Add(title);

            Window.Instance.Add(splashView);

            // Simulate loading and transition to main after 2 seconds
            Timer timer = new Timer(2000);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                ShowMainPage();
                return false;
            };
            timer.Start();
        }

        private void ShowMainPage()
        {
            Window.Instance.GetDefaultLayer().RemoveAllChildren();
            var mainLabel = new TextLabel
            {
                Text = "Welcome to Recipe App!",
                PointSize = 14.0f,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Size = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height),
                TextColor = Color.Black
            };
            Window.Instance.Add(mainLabel);
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Escape")
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
