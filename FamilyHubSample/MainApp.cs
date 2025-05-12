using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace FamilyHubSample
{
    class MainApp : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            InitializeUI();
        }

        void InitializeUI()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TextLabel label = new TextLabel("Welcome to FamilyHub!")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                PointSize = 20.0f,
                TextColor = Color.Black,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent
            };
            window.Add(label);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var app = new MainApp();
            app.Run(args);
        }
    }
}
