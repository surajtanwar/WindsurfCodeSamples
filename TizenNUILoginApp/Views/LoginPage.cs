using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using TizenNUILoginApp.Controllers;
using TizenNUILoginApp.Views;

namespace TizenNUILoginApp
{
    public class LoginPage : ViewBase
    {
        private TextField usernameInput;
        private TextField passwordInput;
        private PushButton loginButton;
        private PushButton signupButton;
        private UserController userController;

        public LoginPage()
        {
            userController = new UserController();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.Center,
                CellPadding = new Size2D(20, 20)
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            var titleLabel = new TextLabel
            {
                Text = "Login",
                PointSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black
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

            loginButton = new PushButton
            {
                Text = "Login",
                Size2D = new Size2D(200, 50),
                BackgroundColor = new Color(0.13f, 0.59f, 0.95f, 1.0f)
            };

            signupButton = new PushButton
            {
                Text = "Create Account",
                Size2D = new Size2D(200, 50),
                BackgroundColor = new Color(0.30f, 0.69f, 0.31f, 1.0f)
            };

            Add(titleLabel);
            Add(usernameInput);
            Add(passwordInput);
            Add(loginButton);
            Add(signupButton);

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
            signupPage.Show();
            Hide();
        }

        private void NavigateToRecipeDetails()
        {
            var recipeDetailsPage = new RecipeDetailsPage();
            recipeDetailsPage.Show();
            Hide();
        }

        private void ShowAlert(string title, string message)
        {
            var dialog = new MessageDialog()
            {
                Title = title,
                Message = message,
                PositiveButton = new PushButton()
                {
                    Text = "OK",
                    BackgroundColor = new Color(0.13f, 0.59f, 0.95f, 1.0f)
                }
            };
            dialog.ShowAsync();
        }
    }
}
