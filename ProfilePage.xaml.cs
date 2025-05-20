namespace TaskPlannerApp;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private async void LogoutClicked(object sender, EventArgs e)
    {
        Preferences.Remove("LoggedInUserID");
        Preferences.Remove("LoggedInUserName");

        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }

}