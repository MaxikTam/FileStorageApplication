using LogicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicApp.DbAccess;

public class FileStorageDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<StoredFile> Files { get; set; }
    public DbSet<LogEvent> LogEvents { get; set; }
    
    public FileStorageDbContext()
    {
        Database.EnsureCreated();   // гарантируем, что БД создана
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=file_storage_app.db");
    }
}