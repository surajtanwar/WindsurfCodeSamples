using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace RecipeApp
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            ShowSplashScreen();
        }

        private View mainContainer;

        private async void ShowSplashScreen()
        {
            var splash = new SplashScreenPage();
            Window.Instance.Add(splash);
            // Show splash for 2 seconds
            await Task.Delay(2000);
            Window.Instance.Remove(splash);
            splash.Dispose();

            // Create a main container for navigation
            mainContainer = new View
            {
                Size = Window.Instance.WindowSize,
                Position = new Position(0, 0),
                PositionUsesPivotPoint = false,
            };
            Window.Instance.Add(mainContainer);

            // Initialize navigation handler singleton with mainContainer as root
            NavigationHandler.Initialize(mainContainer);
            // Show main page using navigation handler singleton
            var mainPage = new RecipeListPage();
            NavigationHandler.Instance.Show(mainPage);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
