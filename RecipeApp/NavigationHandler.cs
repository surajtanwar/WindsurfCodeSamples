using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace RecipeApp
{
    /// <summary>
    /// Handles navigation between pages (Views) in the app.
    /// </summary>
    public class NavigationHandler
    {
        private static NavigationHandler _instance;
        public static NavigationHandler Instance => _instance ?? throw new System.InvalidOperationException("NavigationHandler not initialized. Call Initialize(rootView) first.");

        private readonly Stack<View> navigationStack = new Stack<View>();
        private readonly View rootView;

        private NavigationHandler(View root)
        {
            rootView = root;
        }

        public static void Initialize(View root)
        {
            _instance = new NavigationHandler(root);
        }

        /// <summary>
        /// Show a page (View) and add it to the navigation stack.
        /// </summary>
        public void Show(View page)
        {
            if (navigationStack.Count > 0)
            {
                var current = navigationStack.Peek();
                current.Hide();
            }
            rootView.Add(page);
            page.Show();
            navigationStack.Push(page);
        }

        /// <summary>
        /// Hide the current page and go back to the previous one.
        /// </summary>
        public void Back()
        {
            if (navigationStack.Count > 1)
            {
                var current = navigationStack.Pop();
                current.Hide();
                var previous = navigationStack.Peek();
                previous.Show();
            }
        }

        /// <summary>
        /// Hide the current page.
        /// </summary>
        public void HideCurrent()
        {
            if (navigationStack.Count > 0)
            {
                var current = navigationStack.Peek();
                current.Hide();
            }
        }

        /// <summary>
        /// Show the current page (if hidden).
        /// </summary>
        public void ShowCurrent()
        {
            if (navigationStack.Count > 0)
            {
                var current = navigationStack.Peek();
                current.Show();
            }
        }

        /// <summary>
        /// Clear all navigation and show root.
        /// </summary>
        public void ResetToRoot()
        {
            while (navigationStack.Count > 0)
            {
                var page = navigationStack.Pop();
                page.Hide();
            }
            rootView.Show();
        }
    }
}
