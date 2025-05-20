using TaskPlannerApp.Services;
using TaskPlannerApp.Utils;

namespace TaskPlannerApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var db = new DatabaseService();
        var user = await db.GetUserByEmail(EmailEntry.Text);

        if (user == null || user.PasswordHash != PasswordHelper.HashPassword(PasswordEntry.Text))
        {
            ErrorLabel.Text = "Invalid email or password.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Save session (you can use Preferences or a global state manager)
        Preferences.Set("LoggedInUserID", user.UserID);
        Preferences.Set("LoggedInUserName", user.Name);

        // Navigate to Home/MainPage
        await Shell.Current.GoToAsync("//HomePage");
    }
}