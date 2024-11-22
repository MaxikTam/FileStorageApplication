using LogicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicApp.DbAccess.Repositoryes;

public class FileRepository(FileStorageDbContext context)
{
    public async Task<bool> Add(StoredFile file)
    {
        if (await context.Files
                .AnyAsync(o => 
                    (o.Name == file.Name &
                    o.UserId == file.UserId))) return false;

        await context.Files.AddAsync(file);
        await context.SaveChangesAsync();

        return true;
    }

    public List<string> GetFileNamesByUserName(string userName)
    {
        var files = (from file in context.Files
            where file.User.Name == userName
            select file).ToList();

        return files.Select(f => f.Name).ToList();
    }

    public IEnumerable<FileFilterDb> GetFilters()
    {
        return context.FileFilters.Select(f => f).ToList();
    }

    public async Task<bool> InsertFilter(FileFilterDb filter)
    {
        if (await context.FileFilters.AnyAsync(o => o.Type == filter.Type))
        {
            return false;
        } 
        
        await context.FileFilters.AddAsync(filter);
        await context.SaveChangesAsync();
        return true;
    }
    
    
}