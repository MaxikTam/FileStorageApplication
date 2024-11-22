namespace LogicApp.Models;

public class StoredFile
{
    public int StoredFileId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    /// <summary>
    /// File length in bytes
    /// </summary>
    public long Size { get; set; }

    // Foreign key
    public int UserId { get; set; }
    public User User { get; set; }
}