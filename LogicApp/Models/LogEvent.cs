using LogicApp.Models.Enum;

namespace LogicApp.Models;

public class LogEvent
{
    public int LogEventId { get; set; }
    public DateTime DateTime { get; set; }
    public TypeAction TypeAction { get; set; }
    
    // Foreign Key 1
    public int UserId { get; set; }
    public User User { get; set; }
    
    // Foreign Key 2
    public int FileId { get; set; }
    public StoredFile StoredFile { get; set; }
}