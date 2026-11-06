namespace esantillan.Utils;

public static class FileAccessHelper
{
    public static string GetLocalFilePath(string filename)
    {
        return Path.Combine(FileSystem.AppDataDirectory, filename);
    }
}
