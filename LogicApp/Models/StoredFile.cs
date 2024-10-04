namespace LogicApp.Models;

public class StoredFile
{
    public int StoredFileId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public float Size { get; set; }
    
    // Foreign key
    public int UserId { get; set; }
    public User User { get; set; }
}