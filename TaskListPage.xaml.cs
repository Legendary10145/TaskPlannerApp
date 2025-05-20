using TaskPlannerApp.Models;

namespace TaskPlannerApp;

public partial class TaskListPage : ContentPage
{
    public TaskListPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var db = new DatabaseService();
        await db.Init();

        var userId = Preferences.Get("LoggedInUserID", 0);
        var tasks = await db._db.Table<TaskItem>()
            .Where(t => t.UserID == userId)
            .OrderBy(t => t.DueDate)
            .ToListAsync();

        TaskListView.ItemsSource = tasks;
    }
}
