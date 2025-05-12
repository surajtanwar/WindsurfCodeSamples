using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace TizenNuiLoginApp
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.KeyEvent += (s, e) => { if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Back") Exit(); };
            window.Add(new MainPage().View);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
