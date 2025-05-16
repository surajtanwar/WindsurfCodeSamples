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

        private async void ShowSplashScreen()
        {
            var splash = new SplashScreenPage();
            Window.Instance.Add(splash);
            // Show splash for 2 seconds
            await Task.Delay(2000);
            Window.Instance.Remove(splash);
            splash.Dispose();

            // Show main page
            var mainPage = new RecipeListPage();
            Window.Instance.Add(mainPage);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
