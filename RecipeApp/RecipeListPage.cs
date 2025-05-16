using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    public class RecipeListPage : View
    {
        public RecipeListPage()
        {
            Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height);
            BackgroundColor = new Color(0.95f, 0.95f, 1.0f, 1.0f);

            var title = new TextLabel
            {
                Text = "Recipes",
                PointSize = 14.0f,
                TextColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                Position = new Position(0, 40)
            };
            Add(title);

            string[] recipes = { "Pasta Carbonara", "Chicken Curry", "Avocado Toast" };
            for (int i = 0; i < recipes.Length; i++)
            {
                var recipeLabel = new TextLabel
                {
                    Text = recipes[i],
                    PointSize = 10.0f,
                    TextColor = Color.DarkSlateBlue,
                    Position = new Position(0, 100 + i * 60),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Add(recipeLabel);
            }
        }
    }
}
