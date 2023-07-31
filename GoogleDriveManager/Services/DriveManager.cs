namespace GoogleDriveManager.Services;

using Google.Apis.Drive.v3;
using GoogleDriveManager.Configuration;
using Microsoft.AspNetCore.Http;
using File = Google.Apis.Drive.v3.Data.File;
public interface IDriveService
{
    Task UploadFileAsync(IFormFile file, string folderId);
    Task DeleteFileAsync(string id);
    MemoryStream DownloadFileAsync(string id);
    Task CreateFolderAsync();
    Task DeleteFolderAsync(string id);
    Task<IEnumerable<File>> GetDriveFilesAsync();
}
public class DriveManager : IDriveService
{
    private readonly Configure _configure;
    public DriveManager(string credentialPath)
    {
        _configure = new Configure(credentialPath);
    }
    public Task CreateFolderAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFolderAsync(string id)
    {
        throw new NotImplementedException();
    }

    public MemoryStream DownloadFileAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<File>> GetDriveFilesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UploadFileAsync(IFormFile file, string folderId)
    {
        FilesResource.CreateMediaUpload request;
        File fileMetaData = new File()
        {
            Name = Path.GetFileName(file.FileName),
            Parents = new List<string>() { folderId }
        };
        using (var fileStream = file.OpenReadStream())
        {
            request = _configure.GetDriveService().Files.Create(fileMetaData, fileStream, file.ContentType);
            request.Fields = "id";
            await request.UploadAsync();
        }
    }
}
