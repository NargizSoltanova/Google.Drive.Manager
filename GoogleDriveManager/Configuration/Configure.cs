using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace GoogleDriveManager.Configuration;

public class Configure
{
    private readonly string _credentialPath;
    public Configure(string credentialPath)
    {
        _credentialPath = credentialPath;
    }

    /// <summary>
    /// Creates and returns a <see cref="DriveService"/> instance configured with Google service account credentials for accessing Google Drive files.
    /// </summary>
    /// <param name="credentialPath">The file path to the Google service account credentials.</param>
    /// <returns>A <see cref="DriveService"/> instance with the appropriate configurations.</returns>
    public DriveService GetDriveService()
    {
        GoogleCredential credential;
        using (FileStream fileStream = new FileStream(_credentialPath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(fileStream).CreateScoped(new[] { DriveService.ScopeConstants.DriveFile });
            DriveService driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleApplication"
            });
            return driveService;
        }
    }
}
