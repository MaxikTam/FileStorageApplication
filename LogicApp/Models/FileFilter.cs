using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LogicApp.Models.Enum;
using Microsoft.Extensions.Primitives;
using Microsoft.JSInterop.Implementation;

namespace LogicApp.Models;

public class FileFilter
{
    private List<TypeFile> _typeFiles;
    private long _size;

    public string TypeFile
    {
        get
        {
            var result = new StringBuilder();
            foreach (var type in _typeFiles)
            {
                result.Append('.');
                result.Append(type.ToString().ToLower());
                result.Append(',');
                result.Append(' ');
            }

            return result.ToString().TrimEnd(',');
        }
    }
    
    /// <summary>
    /// File limit in Mb
    /// </summary>
    public double Size => (double) _size / (1024 * 1024);
    
    public FileFilter(FileFilterDb filterDb)
    {
        try
        {
            _typeFiles = JsonSerializer.Deserialize<List<TypeFile>>(filterDb.Type);
            _size = filterDb.Size;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public FileFilter(List<int> typeFiles, int size)
    {
        _typeFiles = typeFiles.Select( x => (TypeFile)x ).ToList();
        _size = size * (1024 * 1024);
    }
}