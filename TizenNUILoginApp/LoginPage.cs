using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace TizenNUILoginApp
{
    public class LoginPage : NUIApplication
    {
        private TextInput usernameInput;
        private TextInput passwordInput;
        private PushButton loginButton;
        private View mainView;
        private Window window;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Create the main window
            window = Window.Instance;
            window.BackgroundColor = Color.White;

            // Create main container
            mainView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Padding(20, 20, 20, 20)
            };

            // Username input
            usernameInput = new TextInput()
            {
                PlaceholderText = "Username",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                Margin = new Margin(0, 0, 0, 10)
            };

            // Password input
            passwordInput = new TextInput()
            {
                PlaceholderText = "Password",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                InputMode = InputMode.Password,
                Margin = new Margin(0, 0, 0, 20)
            };

            // Login button
            loginButton = new PushButton()
            {
                Text = "Login",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50
            };

            // Add login button click event
            loginButton.Clicked += OnLoginClicked;

            // Add controls to main view
            mainView.Add(usernameInput);
            mainView.Add(passwordInput);
            mainView.Add(loginButton);

            // Add main view to window
            window.Add(mainView);
            window.Show();
        }

        private void OnLoginClicked(object sender, ClickedEventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowAlert("Error", "Please enter both username and password.");
                return;
            }

            // Here you would typically validate credentials against a backend
            if (ValidateCredentials(username, password))
            {
                ShowAlert("Success", "Login Successful!");
                // Navigate to recipe details page
                NavigateToRecipeDetails();
            }
            else
            {
                ShowAlert("Error", "Invalid username or password.");
            }
        }

        private bool ValidateCredentials(string username, string password)
        {
            // Placeholder for actual credential validation
            // In a real app, this would check against a backend service
            return username == "admin" && password == "password";
        }

        private void ShowAlert(string title, string message)
        {
            // Create and show an alert dialog
            AlertDialog alert = new AlertDialog()
            {
                Title = title,
                Message = message
            };
            alert.Show();
        }

        public static void Main(string[] args)
        {
            LoginPage app = new LoginPage();
            app.Run(args);
        }

        private void NavigateToRecipeDetails()
        {
            // Remove the login view
            window.Remove(mainView);

            // Create and show the recipe details page
            var recipeDetailsPage = new RecipeDetailsPage();
            window.Add(recipeDetailsPage);
        }
    }
}
