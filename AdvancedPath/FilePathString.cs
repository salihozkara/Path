namespace AdvancedPath;

public sealed class FilePathString : PathString
{
    public FilePathString(string path) : base(path)
    {
    }

    protected override FileInfo FileSystemInfo
    {
        get
        {
            if (Info is not FileInfo fileInfo)
                Info = fileInfo = new FileInfo(Value);
            return fileInfo;
        }
    }

    public string FileName => Path.GetFileName(Value);

    public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(Value);

    public string Extension => Path.GetExtension(Value);

    public static implicit operator FilePathString(FileInfo fileSystemInfo)
    {
        var path = new FilePathString(fileSystemInfo.FullName)
        {
            Info = fileSystemInfo
        };
        return path;
    }

    public static implicit operator string(FilePathString filePathString)
    {
        return filePathString.Value;
    }

    public static implicit operator FilePathString(string path)
    {
        return new FilePathString(path);
    }
    
    public static FilePathString operator +(ValueType left, FilePathString right)
    {
        return new FilePathString(Path.Combine(left.ToString() ?? string.Empty, right.Value));
    }
    
    public static FilePathString operator +(PathString left, FilePathString right)
    {
        return new FilePathString(Path.Combine(left.Value, right.Value));
    }

    public override FilePathString GetRelativePath(string path)
    {
        return base.GetRelativePath(path).ToFilePathString();
    }
}