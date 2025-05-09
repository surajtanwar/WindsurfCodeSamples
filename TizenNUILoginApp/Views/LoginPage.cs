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

        private async void OnLoginClicked(object sender, ClickedEventArgs e)
        {
            string email = usernameInput.Text;
            string password = passwordInput.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await ShowAlertDialog(new AlertDialogOptions("Validation Error", "Please enter both email and password.", AlertType.Warning));
                return;
            }

            if (userController.ValidateLogin(email, password))
            {
                await ShowAlertDialog(new AlertDialogOptions("Welcome", "Login Successful!", AlertType.Success));
                NavigateToRecipeDetails();
            }
            else
            {
                await ShowAlertDialog(new AlertDialogOptions("Authentication Failed", "Invalid email or password.", AlertType.Error));
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

        /// <summary>
        /// Defines the type of alert message to be displayed.
        /// </summary>
        private enum AlertType
        {
            /// <summary>General information message (default)</summary>
            Info,
            /// <summary>Positive outcome or successful operation</summary>
            Success,
            /// <summary>Cautionary message or potential issue</summary>
            Warning,
            /// <summary>Error condition or operation failure</summary>
            Error
        }

        /// <summary>
        /// Options for configuring an alert dialog.
        /// </summary>
        private class AlertDialogOptions
        {
            /// <summary>The title of the alert dialog</summary>
            public string Title { get; set; }

            /// <summary>The main message content of the alert</summary>
            public string Message { get; set; }

            /// <summary>The type of alert which determines the color scheme</summary>
            public AlertType Type { get; set; } = AlertType.Info;

            /// <summary>The text to display on the confirmation button</summary>
            public string ButtonText { get; set; } = "OK";

            /// <summary>
            /// Creates a new instance of AlertDialogOptions with required parameters.
            /// </summary>
            public AlertDialogOptions(string title, string message)
            {
                Title = title;
                Message = message;
            }

            /// <summary>
            /// Creates a new instance of AlertDialogOptions with all parameters.
            /// </summary>
            public AlertDialogOptions(string title, string message, AlertType type, string buttonText = "OK")
            {
                Title = title;
                Message = message;
                Type = type;
                ButtonText = buttonText;
            }
        }

        /// <summary>
        /// Defines standard colors for different types of alerts.
        /// Colors use RGBA values in the range 0-1.
        /// </summary>
        private static class AlertColors
        {
            public static readonly Color Primary = new Color(0.13f, 0.59f, 0.95f, 1.0f);   // Blue
            public static readonly Color Success = new Color(0.30f, 0.69f, 0.31f, 1.0f);   // Green
            public static readonly Color Warning = new Color(1.0f, 0.64f, 0.0f, 1.0f);     // Orange
            public static readonly Color Error = new Color(0.96f, 0.26f, 0.21f, 1.0f);     // Red
        }

        /// <summary>
        /// Displays an asynchronous alert dialog with customizable appearance.
        /// </summary>
        /// <param name="options">The options for configuring the alert dialog.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <remarks>
        /// The alert dialog's appearance changes based on the AlertType in options:
        /// - Info: Blue color scheme for general information
        /// - Success: Green color scheme for positive outcomes
        /// - Warning: Orange color scheme for cautionary messages
        /// - Error: Red color scheme for error conditions
        /// </remarks>
        /// <example>
        /// <code>
        /// // Display a success message
        /// await ShowAlertDialog(new AlertDialogOptions("Success", "Operation completed!", AlertType.Success));
        /// 
        /// // Display an error with custom button text
        /// await ShowAlertDialog(new AlertDialogOptions("Error", "Operation failed", AlertType.Error, "Try Again"));
        /// </code>
        /// </example>
        private async Task ShowAlertDialog(AlertDialogOptions options)
        {
            if (options == null || string.IsNullOrEmpty(options.Title) || string.IsNullOrEmpty(options.Message))
            {
                return;
            }

            Color buttonColor = options.Type switch
            {
                AlertType.Success => AlertColors.Success,
                AlertType.Warning => AlertColors.Warning,
                AlertType.Error => AlertColors.Error,
                _ => AlertColors.Primary
            };

            try
            {
                var dialog = new MessageDialog()
                {
                    Title = options.Title,
                    Message = options.Message,
                    PositiveButton = new PushButton()
                    {
                        Text = options.ButtonText,
                        BackgroundColor = buttonColor,
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                        HeightSpecification = 40,
                        Margin = new Extents(10, 10, 5, 5)
                    }
                };

                await dialog.ShowAsync();
        }
    }
}
