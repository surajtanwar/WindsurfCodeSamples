using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace nuisample
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            var recipeDetail = new Views.RecipeDetailView();
            Window.Instance.Add(recipeDetail);
        }


        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
