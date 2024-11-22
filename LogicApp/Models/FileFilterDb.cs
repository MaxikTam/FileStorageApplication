using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LogicApp.Models;

public class FileFilterDb
{
    [Key]
    public int Type { get; set; }
    /// <summary>
    /// File limit on it`s lingth in bytes
    /// </summary>
    public long Size { get; set; }
}