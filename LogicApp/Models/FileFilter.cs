using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LogicApp.Models.Enum;
using Microsoft.Extensions.Primitives;
using Microsoft.JSInterop.Implementation;

namespace LogicApp.Models;

public class FileFilter()
{
    /// <summary>
    /// По умолчанию, нельзя загружать файлы, размером более 20 Мб.
    /// </summary>
    private const double Default = 20;

    public Dictionary<TypeFile, long> ExtensionSize { get; set; } = new();
    
    /// <summary>
    /// Разрешённые расширения в строковом виде.
    /// </summary>
    public string Extensions
    {
        get
        {
            var result = new StringBuilder();
            foreach (var type in ExtensionSize.Keys)
            {
                result.Append('.');
                result.Append('.');
                result.Append(type.ToString().ToLower());
                result.Append(',');
                result.Append(' ');
            }

            return result.ToString().TrimEnd(',');    
        }
    }

    /// <summary>
    /// Ограничение размера файла в Mb
    /// </summary>
    public double GetExtensionSizeLimit(TypeFile typeFile)
    {
        if (!ExtensionSize.TryGetValue(typeFile, out var size))
        {
            return Default;
        }
        return (double)ExtensionSize[typeFile] / (1024 * 1024);
    }
    
}