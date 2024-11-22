namespace LogicApp.Models;

public class FileFilterDb
{
    public int FileFilterId { get; set; }
    public string Type { get; set; }
    /// <summary>
    /// File limit on it`s lingth in bytes
    /// </summary>
    public long Size { get; set; }
}