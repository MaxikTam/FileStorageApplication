using LogicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicApp.DbAccess;

public sealed class FileStorageDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<StoredFile> Files { get; set; }
    public DbSet<LogEvent> LogEvents { get; set; }
    public DbSet<FileFilterDb> FileFilters { get; set; }
    
    public FileStorageDbContext(DbContextOptions<FileStorageDbContext> options)
        : base(options)
    {  
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
}