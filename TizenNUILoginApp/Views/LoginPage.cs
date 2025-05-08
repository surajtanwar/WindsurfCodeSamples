using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using TizenNUILoginApp.Controllers;

namespace TizenNUILoginApp.Views
{
    public class LoginPage : ContentPage
    {
        private TextField usernameInput;
        private TextField passwordInput;
        private Button loginButton;
        private Button signupButton;
        private UserController userController;

        public LoginPage()
        {
            userController = new UserController();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var window = Window.Instance;
            BackgroundColor = new Color("#FFFFFF");

            var stackLayout = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(20, 20)
                },
                Size = new Size(window.Size.Width, window.Size.Height),
                BackgroundColor = new Color("#FFFFFF")
            };

            var titleLabel = new TextLabel
            {
                Text = "Login",
                PointSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = new Color("#000000")
            };

            usernameInput = new TextField
            {
                PlaceholderText = "Email",
                PointSize = 14,
                Size = new Size(300, 40)
            };

            passwordInput = new TextField
            {
                PlaceholderText = "Password",
                PointSize = 14,
                Size = new Size(300, 40)
            };
            passwordInput.InputMethodSettings.Mode = InputMethod.Mode.Password;

            loginButton = new Button
            {
                Text = "Login",
                Size = new Size(200, 50),
                BackgroundColor = new Color("#2196F3")
            };

            signupButton = new Button
            {
                Text = "Create Account",
                Size = new Size(200, 50),
                BackgroundColor = new Color("#4CAF50")
            };

            stackLayout.Add(titleLabel);
            stackLayout.Add(usernameInput);
            stackLayout.Add(passwordInput);
            stackLayout.Add(loginButton);
            stackLayout.Add(signupButton);

            Add(stackLayout);

            loginButton.Clicked += OnLoginClicked;
            signupButton.Clicked += OnSignupClicked;
        }

        private void OnLoginClicked(object sender, ClickedEventArgs e)
        {
            string email = usernameInput.Text;
            string password = passwordInput.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ShowAlert("Error", "Please enter both email and password.");
                return;
            }

            if (userController.ValidateLogin(email, password))
            {
                ShowAlert("Success", "Login Successful!");
                NavigateToRecipeDetails();
            }
            else
            {
                ShowAlert("Error", "Invalid email or password.");
            }
        }

        private void OnSignupClicked(object sender, ClickedEventArgs e)
        {
            var signupPage = new SignupPage();
            Window.Instance.GetDefaultLayer().Add(signupPage);
            this.Hide();
        }

        private void NavigateToRecipeDetails()
        {
            var recipeDetailsPage = new RecipeDetailsPage();
            Window.Instance.GetDefaultLayer().Add(recipeDetailsPage);
            this.Hide();
        }

        private void ShowAlert(string title, string message)
        {
            var alert = new AlertDialog()
            {
                Title = title,
                Message = message
            };
            alert.Show();
        }
    }
}
