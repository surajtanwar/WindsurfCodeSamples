using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace nuisample
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            var text = new TextLabel
            {
                Text = "Hello, Tizen NUI!",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                PointSize = 20.0f,
                Size2D = new Size2D(360, 100),
                Position2D = new Position2D(30, 400)
            };
            Window.Instance.Add(text);
        }
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
