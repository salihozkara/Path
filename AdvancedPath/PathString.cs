namespace AdvancedPath;

public class PathString
{
    // Fields

    private PathType? _pathType;
    private readonly string? _path;
    
    protected FileSystemInfo? Info;

    protected virtual FileSystemInfo FileSystemInfo => Info ??= GetFileSystemInfo();

    private FileSystemInfo GetFileSystemInfo()
    {
        if (Type == PathType.File)
            return new FileInfo(_path!);
        if (Type == PathType.Directory)
            return new DirectoryInfo(_path!);
        return null!;
    }

    // Constructors
    public PathString(string path)
    {
        _path = NormalizePath(path);
    }

    // Properties

    public string Value => _path ?? string.Empty;

    public bool IsFullPath => IsValid && Path.IsPathRooted(Value);
    public string FullPath => IsValid ? Path.GetFullPath(Value) : Value;
    
    public virtual string Name => FileSystemInfo?.Name ?? string.Empty;

    public bool Exists => IsValid && (File.Exists(Value) || Directory.Exists(Value));

    public virtual DirectoryPathString ParentDirectory => Directory.GetParent(Value)?.FullName ?? string.Empty;
    private bool IsValid => ValidatePath();
    public PathType Type => _pathType ??= GetPathType();


    // Methods

    public virtual void CreateIfNotExists()
    {
        if (Exists)
            return;

        Info = null;
        ParentDirectory.CreateIfNotExists();
        if (this is FilePathString)
            File.Create(Value).Close();
        else if (this is DirectoryPathString)
            Info = Directory.CreateDirectory(Value);
    }

    public virtual void DeleteIfExists()
    {
        if (!Exists)
            return;

        if (Type == PathType.File)
            File.Delete(Value);
        else if (Type == PathType.Directory)
            Directory.Delete(Value);

        Info = null;
    }
    
    public virtual PathString GetRelativePath(string path)
    {
        return Path.GetRelativePath(path, Value);
    }

    public DirectoryPathString ToDirectoryPathString()
    {
        return new DirectoryPathString(Value);
    }

    public FilePathString ToFilePathString()
    {
        return new FilePathString(Value);
    }


    public override bool Equals(object? obj)
    {
        return Equals(obj?.ToString() ?? string.Empty);
    }

    public override int GetHashCode()
    {
        return FullPath.GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }
    
    private bool ValidatePath()
    {
        return !string.IsNullOrWhiteSpace(Value) && !Path.GetInvalidPathChars().Any(Value.Contains);
    }
    
    private static string NormalizePath(string path)
    {
        if(path.EndsWith(Path.DirectorySeparatorChar) || path.EndsWith(Path.AltDirectorySeparatorChar))
            path = path[..^1];
        return path.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
    }

    private PathType GetPathType()
    {
        if (!IsValid) return PathType.Invalid;
        if (Exists) return File.Exists(Value) ? PathType.File : PathType.Directory;

        return PathType.Unknown;
    }
    
    private bool Equals(PathString other)
    {
        var tempFullPath = FullPath;
        tempFullPath = tempFullPath.EndsWith(Path.DirectorySeparatorChar) ? tempFullPath : tempFullPath + Path.DirectorySeparatorChar;
        var otherFullPath = other.FullPath;
        otherFullPath = otherFullPath.EndsWith(Path.DirectorySeparatorChar) ? otherFullPath : otherFullPath + Path.DirectorySeparatorChar;
        return tempFullPath.Equals(otherFullPath, StringComparison.OrdinalIgnoreCase);
    }


    // Operators

    public static implicit operator string(PathString pathString)
    {
        return pathString.Value;
    }

    public static implicit operator PathString(string path)
    {
        var pathString = new PathString(path);
        return pathString.Type switch
        {
            PathType.File => new FilePathString(path),
            PathType.Directory => new DirectoryPathString(path),
            PathType.Invalid => new InvalidPathString(),
            _ => pathString
        };
    }

    public static bool operator ==(PathString pathString, string value)
    {
        return pathString.Equals(value);
    }

    public static bool operator !=(PathString pathString, string value)
    {
        return !(pathString == value);
    }

    public static bool operator ==(string value, PathString pathString)
    {
        return pathString.Equals(value);
    }

    public static bool operator !=(string value, PathString pathString)
    {
        return !(value == pathString);
    }

    public static bool operator ==(PathString pathString1, PathString pathString2)
    {
        return pathString1.Equals(pathString2);
    }

    public static bool operator !=(PathString pathString1, PathString pathString2)
    {
        return !(pathString1 == pathString2);
    }

    public static bool operator !(PathString pathString)
    {
        return pathString ? false : true;
    }

    
    
    public static bool operator true(PathString pathString)
    {
        return pathString.Exists;
    }

    public static bool operator false(PathString pathString)
    {
        return pathString ? false : true;
    }


    
    
    public static PathString operator +(PathString pathString1, PathString pathString2)
    {
        return Path.Combine(pathString1.Value, pathString2.Value);
    }
    
    public static PathString operator +(PathString pathString, string path)
    {
        return pathString + (PathString) path;
    }
    
    public static PathString operator +(string path, PathString pathString)
    {
        return (PathString) path + pathString;
    }

    public static PathString operator +(PathString pathString, ValueType path)
    {
        return pathString + (path.ToString() ?? string.Empty);
    }

    public static PathString operator +(ValueType path, PathString pathString)
    {
        return (path.ToString() ?? string.Empty) + pathString;
    }
    
    public static DirectoryPathString operator --(PathString pathString)
    {
        return pathString.ParentDirectory;
    }
    
    public static bool operator <(PathString pathString1, PathString pathString2)
    {
        var tempPathString = pathString2;
        while (tempPathString.IsValid)
        {
            tempPathString--;
            if(tempPathString == pathString1)
                return true; 
        }
        
        return false;
    }
    
    public static bool operator <=(PathString pathString1, PathString pathString2)
    {
        return pathString1 == pathString2 || pathString1 < pathString2;
    }

    public static bool operator >=(PathString pathString1, PathString pathString2)
    {
        return pathString2 <= pathString1;
    }

    public static bool operator >(PathString pathString1, PathString pathString2)
    {
        return pathString2 < pathString1;
    }
}