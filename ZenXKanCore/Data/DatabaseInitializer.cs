namespace ZenXKanCore.Configurations;

public class DatabaseInitializer
{
    public string InitializeDatabase()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var dbFolderPath = Path.Join(path, "ZenXKanData");

        if (!Directory.Exists(dbFolderPath)) Directory.CreateDirectory(dbFolderPath);

        return Path.Join(dbFolderPath, "zenxkan.db");
    }
}