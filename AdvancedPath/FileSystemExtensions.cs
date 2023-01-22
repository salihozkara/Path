namespace AdvancedPath;

public static class FileSystemExtensions
{
    public static IEnumerable<FilePathString> CastToFilePathString(this IEnumerable<FileInfo> paths)
    {
        return paths.Select<FileInfo,FilePathString>(x => x);
    }
    
    public static IEnumerable<DirectoryPathString> CastToDirectoryPathString(this IEnumerable<DirectoryInfo> paths)
    {
        return paths.Select<DirectoryInfo,DirectoryPathString>(x => x);
    }
}