using SQLite;
using TaskPlannerApp.Models;
using TaskPlannerApp.Services;

namespace TaskPlannerApp;

public partial class AddTaskPage : ContentPage
{
	public AddTaskPage()
	{
		InitializeComponent();
	}

    private async void SaveTask_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text) || PriorityPicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please enter title and select priority.", "OK");
            return;
        }

        var task = new TaskItem
        {
            Title = TitleEntry.Text,
            Description = DescriptionEditor.Text,
            DueDate = DueDatePicker.Date,
            Priority = PriorityPicker.SelectedItem.ToString(),
            UserID = Preferences.Get("LoggedInUserID", 0),
            Status = "Pending"
        };

        var db = new DatabaseService();
        await db.Init();
        await db.InsertTaskAsync(task); // Use a public method to insert the task

        await DisplayAlert("Success", "Task added!", "OK");
        await Shell.Current.GoToAsync(".."); // go back
    }
}
public class DatabaseService
{
    private SQLiteAsyncConnection _db;

    public async Task Init()
    {
        // Initialization logic for _db
    }

    public async Task InsertTaskAsync(TaskItem task)
    {
        if (_db == null)
        {
            throw new InvalidOperationException("Database not initialized. Call Init() first.");
        }

        await _db.InsertAsync(task);
    }
}