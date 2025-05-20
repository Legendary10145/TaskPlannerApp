using SQLite;

namespace TaskPlannerApp.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int UserID { get; set; }

    [MaxLength(100), NotNull]
    public string Name { get; set; }

    [MaxLength(100), NotNull, Unique]
    public string Email { get; set; }

    [NotNull]
    public string PasswordHash { get; set; }
}