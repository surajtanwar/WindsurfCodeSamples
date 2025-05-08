using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TizenNUILoginApp
{
    public class SignupPage : ContentPage
    {
        private ScrollableBase scrollContainer;
        private View contentContainer;
        private TextField fullNameField;
        private TextField emailField;
        private TextField passwordField;
        private TextField confirmPasswordField;
        private TextField phoneField;
        private TextField addressField;
        private DatePicker dobPicker;
        private Button profilePictureButton;
        private ImageView profileImageView;
        private Button signupButton;
        private TextLabel validationLabel;

        public SignupPage()
        {
            InitializeComponents();
            CreateLayout();
            RegisterEvents();
        }

        private void InitializeComponents()
        {
            // Initialize scroll container
            scrollContainer = new ScrollableBase
            {
                Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height),
                ScrollingDirection = ScrollableBase.Direction.Vertical
            };

            // Main content container
            contentContainer = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(20, 20)
                },
                Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height),
                Padding = new Extents(20, 20, 20, 20)
            };

            // Title
            var titleLabel = new TextLabel
            {
                Text = "Create Account",
                PointSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = new Color("#000000"),
                Margin = new Extents(0, 0, 20, 40)
            };

            // Required Fields
            fullNameField = CreateTextField("Full Name", "Enter your full name");
            emailField = CreateTextField("Email Address", "Enter your email");
            passwordField = CreateTextField("Password", "Enter your password", true);
            confirmPasswordField = CreateTextField("Confirm Password", "Confirm your password", true);
            
            // Optional Fields
            phoneField = CreateTextField("Phone Number (Optional)", "Enter your phone number");
            addressField = CreateTextField("Address (Optional)", "Enter your address");
            
            // Date of Birth
            dobPicker = new DatePicker
            {
                Size = new Size(400, 50),
                Margin = new Extents(0, 0, 10, 10)
            };

            // Profile Picture
            profilePictureButton = new Button
            {
                Text = "Upload Profile Picture",
                Size = new Size(200, 50),
                Margin = new Extents(0, 0, 10, 20)
            };

            profileImageView = new ImageView
            {
                Size = new Size(100, 100),
                CornerRadius = 50.0f,
                Margin = new Extents(0, 0, 10, 20),
                Visible = false
            };

            // Signup Button
            signupButton = new Button
            {
                Text = "Sign Up",
                Size = new Size(200, 50),
                BackgroundColor = new Color("#2196F3"),
                Margin = new Extents(0, 0, 20, 0)
            };

            // Validation Label
            validationLabel = new TextLabel
            {
                Text = "",
                TextColor = new Color("#FF0000"),
                PointSize = 12,
                MultiLine = true,
                Size = new Size(400, 60),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            // Add all components to the container
            contentContainer.Add(titleLabel);
            contentContainer.Add(fullNameField);
            contentContainer.Add(emailField);
            contentContainer.Add(passwordField);
            contentContainer.Add(confirmPasswordField);
            contentContainer.Add(phoneField);
            contentContainer.Add(addressField);
            contentContainer.Add(dobPicker);
            contentContainer.Add(profilePictureButton);
            contentContainer.Add(profileImageView);
            contentContainer.Add(signupButton);
            contentContainer.Add(validationLabel);

            scrollContainer.Add(contentContainer);
            Add(scrollContainer);
        }

        private TextField CreateTextField(string label, string placeholder, bool isPassword = false)
        {
            var field = new TextField
            {
                Size = new Size(400, 50),
                Margin = new Extents(0, 0, 10, 10),
                PlaceholderText = placeholder,
                PlaceholderTextColor = new Color("#999999"),
                BackgroundColor = new Color("#FFFFFF"),
                PointSize = 14
            };

            if (isPassword)
            {
                field.InputMethodSettings.Mode = InputMethod.Mode.Password;
            }

            return field;
        }

        private void RegisterEvents()
        {
            signupButton.Clicked += OnSignupButtonClicked;
            profilePictureButton.Clicked += OnProfilePictureButtonClicked;
        }

        private void OnSignupButtonClicked(object sender, ClickedEventArgs e)
        {
            if (ValidateInputs())
            {
                // TODO: Implement actual signup logic
                // For now, just show success message
                validationLabel.Text = "Account created successfully!";
                validationLabel.TextColor = new Color("#4CAF50");
            }
        }

        private void OnProfilePictureButtonClicked(object sender, ClickedEventArgs e)
        {
            // TODO: Implement image picker functionality
            // For demonstration, we'll just show a placeholder image
            profileImageView.ResourceUrl = "images/default_profile.png";
            profileImageView.Visible = true;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(fullNameField.Text))
            {
                ShowValidationError("Please enter your full name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailField.Text) || !IsValidEmail(emailField.Text))
            {
                ShowValidationError("Please enter a valid email address");
                return false;
            }

            if (string.IsNullOrWhiteSpace(passwordField.Text) || passwordField.Text.Length < 6)
            {
                ShowValidationError("Password must be at least 6 characters long");
                return false;
            }

            if (passwordField.Text != confirmPasswordField.Text)
            {
                ShowValidationError("Passwords do not match");
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message)
        {
            validationLabel.Text = message;
            validationLabel.TextColor = new Color("#FF0000");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void CreateLayout()
        {
            BackgroundColor = new Color("#F5F5F5");
        }
    }
}
