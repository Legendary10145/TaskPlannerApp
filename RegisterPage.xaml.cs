using TaskPlannerApp.Models;
using TaskPlannerApp.Services;
using TaskPlannerApp.Utils;

namespace TaskPlannerApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
        InitializeComponent();
	}

    private async void RegisterClicked(object sender, EventArgs e)
    {
        var db = new DatabaseService();

        string hashedPassword = PasswordHelper.HashPassword(PasswordEntry.Text);
        var user = new User
        {
            Name = NameEntry.Text,
            Email = EmailEntry.Text,
            PasswordHash = hashedPassword
        };

        await db.RegisterUser(user);
        await DisplayAlert("Success", "Account created!", "OK");
    }
}