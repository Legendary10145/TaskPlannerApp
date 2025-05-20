using SQLite;

namespace TaskPlannerApp.Models;

public class TaskItem
{
    [PrimaryKey, AutoIncrement]
    public int TaskID { get; set; }

    public int UserID { get; set; } // FK to logged-in user

    [MaxLength(100), NotNull]
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public string Priority { get; set; } // e.g., "High", "Medium", "Low"

    public string Status { get; set; } = "Pending"; // or "Completed"
}
