namespace AdvancedPath;

public sealed class DirectoryPathString : PathString
{
    public DirectoryPathString(string path) : base(path)
    {
    }
    
    public DirectoryPathString[] GetDirectories()
    {
        return FileSystemInfo.GetDirectories().CastToDirectoryPathString().ToArray();
    }
    
    public DirectoryPathString[] GetDirectories(string searchPattern)
    {
        return FileSystemInfo.GetDirectories(searchPattern).CastToDirectoryPathString().ToArray();
    }
    
    public DirectoryPathString[] GetDirectories(string searchPattern, SearchOption searchOption)
    {
        return FileSystemInfo.GetDirectories(searchPattern, searchOption).CastToDirectoryPathString().ToArray();
    }
    
    public DirectoryPathString[] GetDirectories(string searchPattern, EnumerationOptions enumerationOptions)
    {
        return FileSystemInfo.GetDirectories(searchPattern, enumerationOptions).CastToDirectoryPathString().ToArray();
    }
    
    public FilePathString[] GetFiles()
    {
        return FileSystemInfo.GetFiles().CastToFilePathString().ToArray();
    }
    
    public FilePathString[] GetFiles(string searchPattern)
    {
        return FileSystemInfo.GetFiles(searchPattern).CastToFilePathString().ToArray();
    }
    
    public FilePathString[] GetFiles(string searchPattern, SearchOption searchOption)
    {
        return FileSystemInfo.GetFiles(searchPattern, searchOption).CastToFilePathString().ToArray();
    }
    
    public FilePathString[] GetFiles(string searchPattern, EnumerationOptions enumerationOptions)
    {
        return FileSystemInfo.GetFiles(searchPattern, enumerationOptions).CastToFilePathString().ToArray();
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