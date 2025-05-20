using TaskPlannerApp.Services;

namespace TaskPlannerApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window();

        if (Preferences.ContainsKey("LoggedInUserID"))
        {
            window.Page = new AppShell(); // already logged in
        }
        else
        {
            window.Page = new NavigationPage(new LoginPage()); // go to login
        }

        return window;
    }

    protected override void OnStart()
    {
        var dbService = new DatabaseService();
        dbService.Init().Wait();
    }
}