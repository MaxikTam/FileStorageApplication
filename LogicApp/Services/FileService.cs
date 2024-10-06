using LogicApp.DbAccess.Repositoryes;
using LogicApp.Models;
using System.IO;

namespace LogicApp.Services;

public class FileService(
    FileRepository fileRepository,
    UserRepository userRepository,
    IWebHostEnvironment appEnvironment)
{

    private readonly string _prefixPath = appEnvironment.WebRootPath + "\\Files\\";
    public async Task<bool> Upload(IFormFile uploadedFile, string userName)
    {
        if (uploadedFile == null) return false;

        var user = await userRepository.GetByUserName(userName);
        var path = userName + "\\" + uploadedFile.FileName;

        await using (var fileStream = new FileStream(_prefixPath + path, (FileMode) 2))
        {
            await uploadedFile.CopyToAsync(fileStream);
        }
        
        var file = new StoredFile
        {
            Name = uploadedFile.FileName, 
            Path = path,
            UserId = user.Id
        };
            
        return await fileRepository.Add(file);
    }

    public List<string> GetFileNamesByUserName(string userName)
    {
        return fileRepository.GetFileNamesByUserName(userName);
    }

    public string GetFilePathByName(string userName, string filename)
    {
        return _prefixPath + userName + "\\" + filename;
    }
}