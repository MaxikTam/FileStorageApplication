using System.Text;
using LogicApp.Models.Enum;

namespace LogicApp.Views.Admin;

public class Filters_cshtml
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