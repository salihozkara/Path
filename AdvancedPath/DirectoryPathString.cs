namespace AdvancedPath;

public sealed class DirectoryPathString : PathString
{
    public DirectoryPathString(string path) : base(path)
    {
    }

    public override DirectoryInfo FileSystemInfo
    {
        get
        {
            if (Info is not DirectoryInfo directoryInfo)
                Info = directoryInfo = new DirectoryInfo(Value);
            return directoryInfo;
        }
    }

    public static implicit operator DirectoryPathString(DirectoryInfo fileSystemInfo)
    {
        var path = new DirectoryPathString(fileSystemInfo.FullName)
        {
            Info = fileSystemInfo
        };
        return path;
    }

    public static implicit operator DirectoryPathString(string path)
    {
        return new DirectoryPathString(path);
    }

    public override DirectoryPathString GetRelativePath(string path)
    {
        return base.GetRelativePath(path).ToDirectoryPathString();
    }
}