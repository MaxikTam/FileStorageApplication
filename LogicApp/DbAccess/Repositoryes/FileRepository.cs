﻿using LogicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicApp.DbAccess.Repositoryes;

public class FileRepository(FileStorageDbContext context)
{
    public async Task<bool> Add(StoredFile file)
    {
        if (await context.Files
                .AnyAsync(o => o.Name == file.Name)) return false;

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
}