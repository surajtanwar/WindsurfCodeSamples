using Tizen.NUI;
using TizenNUILoginApp.Views;

namespace TizenNUILoginApp
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            var loginPage = new LoginPage();
            loginPage.Show();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
