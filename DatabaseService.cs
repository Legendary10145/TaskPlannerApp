using System.IO;
using System.Threading.Tasks;
using TaskPlannerApp.Models;

public async Task Init()
{
    if (_db != null) return;

    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "taskplanner.db");
    _db = new SQLiteAsyncConnection(dbPath);

    await _db.CreateTableAsync<User>();
    await _db.CreateTableAsync<TaskItem>(); 
}
