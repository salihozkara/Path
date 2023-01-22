namespace Test;

public class PathStringTest
{
    private readonly string _userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    
    
    [Test]
    public void FullPath()
    {
        var path = new PathString(_userPath);
        Assert.That(path.FullPath, Is.EqualTo(_userPath));
    }
    
    [Test]
    public void Name()
    {
        var path = new PathString(_userPath);
        Assert.That(path.Name, Is.EqualTo(Path.GetFileName(_userPath)));
    }
    
    [Test]
    public void FromString()
    {
        PathString path = _userPath;
        Assert.That(path.ToString(), Is.EqualTo(_userPath));
    }
    
    [Test]
    public void FromStringWithTrailingSlash()
    {
        PathString directoryPathString = _userPath + Path.DirectorySeparatorChar;
        Assert.That(directoryPathString.FullPath, Is.EqualTo(_userPath));
    }
    
    [Test]
    public void FromStringWithTrailingBackslash()
    {
        PathString directoryPathString = _userPath + Path.AltDirectorySeparatorChar;
        Assert.That(directoryPathString.FullPath, Is.EqualTo(_userPath));
    }
    
    [Test]
    public void Parent()
    {
        var path = new PathString(Path.Combine(_userPath, "test"));
        var parent = path.ParentDirectory;
        Assert.That(parent.FullPath, Is.EqualTo(_userPath));
    }
    
    [Test]
    public void Root(){
        var path = new PathString(_userPath);
        var root = path.RootDirectory;
        Assert.That(root.FullPath, Is.EqualTo(Path.GetPathRoot(_userPath)));
    }
    
    [Test]
    public void MinusMinus()
    {
        var path = new PathString(Path.Combine(_userPath, "test"));
        path--;
        Assert.That(path.FullPath, Is.EqualTo(_userPath));
    }
    
    [Test]
    public void Exists()
    {
        var pathString = new PathString(_userPath);
        Assert.That(pathString.Exists, Is.True);
    }
    
    [Test]
    public void CreateIfNotExistsAndDeleteIfNotExists()
    {
        var path = Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252");
        var pathString = new PathString(path);
        pathString = pathString.ToDirectoryPathString();
        pathString.CreateIfNotExists();
        Assert.That(pathString.Exists, Is.True);
        pathString.DeleteIfExists();
        Assert.That(pathString.Exists, Is.False);
        
        pathString = pathString.ToFilePathString();
        pathString.CreateIfNotExists();
        Assert.That(pathString.Exists, Is.True);
        pathString.DeleteIfExists();
        Assert.That(pathString.Exists, Is.False);
    }
    
    [Test]
    public void GetRelativePath()
    {
        var pathString = new PathString(_userPath);
        var relativePath = pathString.GetRelativePath(_userPath);
        Assert.That(relativePath.Value, Is.EqualTo("."));
    }
    
    [Test]
    public void ConvertToDirectoryPathString()
    {
        var pathString = new PathString(_userPath);
        var directoryPathString = pathString.ToDirectoryPathString();
        Assert.Multiple(() =>
        {
            Assert.That(directoryPathString.Type, Is.EqualTo(PathType.Directory));
            Assert.That(directoryPathString.Value, Is.EqualTo(_userPath));
        });
    }

    [Test]
    public void ConvertToDirectoryPathString2()
    {
        var pathString = new PathString(Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252"));
        var directoryPathString = pathString.ToDirectoryPathString();
        Assert.Multiple(() =>
        {
            Assert.That(directoryPathString.Type, Is.EqualTo(PathType.Unknown));
            Assert.That(directoryPathString.Value, Is.EqualTo(Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252")));
        });
    }

    [Test]
    public void ConvertToFilePathString()
    {
        var firstFile = Directory.GetFiles(_userPath).First();
        var pathString = new PathString(firstFile);
        var filePathString = pathString.ToFilePathString();
        Assert.Multiple(() =>
        {
            Assert.That(filePathString.Type, Is.EqualTo(PathType.File));
            Assert.That(filePathString.Value, Is.EqualTo(firstFile));
        });
    }
    
    [Test]
    public void ConvertToFilePathString2()
    {
        var path = Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252");
        var pathString = new PathString(path);
        var filePathString = pathString.ToFilePathString();
        Assert.Multiple(() =>
        {
            Assert.That(filePathString.Type, Is.EqualTo(PathType.Unknown));
            Assert.That(filePathString.Value, Is.EqualTo(path));
        });
    }
    
    [Test]
    public void Equals()
    {
        var pathString = new PathString(_userPath);
        var pathString2 = new PathString(_userPath);
        Assert.That(pathString.Equals(pathString2), Is.True);
    }
    
    [Test]
    public void Equals2()
    {
        var pathString = new PathString(_userPath);
        var pathString2 = new PathString(_userPath);
        Assert.That(pathString == pathString2, Is.True);
    }

    [Test]
    public void Convert()
    {
        var path = "C:\\Users\\User\\Desktop\\Test.txt";
        
        PathString pathString = path;
        
        string pathString2 = pathString;
        
        Assert.That(pathString2, Is.EqualTo(path));
    }
    
    [Test]
    public void PlusOperator()
    {
        var path = "C:\\Users\\User\\Desktop\\Test.txt";
        
        PathString pathString = path;
        
        var pathString2 = pathString + "Test2.txt";
        
        path = Path.Combine(path, "Test2.txt");
        
        Assert.That(pathString2.FullPath, Is.EqualTo(path));
    }
    
    [Test]
    public void TrueAndFalseOperator()
    {
        var path = Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252");
        
        PathString pathString = path;
        
        var exist = pathString ? true : false;

        Assert.That(exist, Is.EqualTo(pathString.Exists));
    }
    
    [Test]
    public void IsSmallerThanOperator()
    {
        var path = Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252");
        
        PathString pathString = path;
        
        var isSmaller = pathString < pathString.ParentDirectory;

        Assert.That(isSmaller, Is.False);
    }
    
    [Test]
    public void IsSmallerOrEqualThanOperator()
    {
        var path = Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252");
        
        PathString pathString = path;
        
        var isSmaller = pathString <= pathString.ParentDirectory;
        
        var isEquals = Directory.GetParent(path)!.FullName <= pathString.ParentDirectory;
        Assert.Multiple(() =>
        {
            Assert.That(isSmaller, Is.False);
            Assert.That(isEquals, Is.True);
        });
    }
    
    [Test]
    public void IsGreaterThanOperator()
    {
        var path = Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252");
        
        PathString pathString = path;
        
        var isGreater = pathString > pathString.ParentDirectory;

        Assert.That(isGreater, Is.True);
    }
    
    [Test]
    public void IsGreaterOrEqualThanOperator()
    {
        var path = Path.Combine(_userPath, "8B72B215-9306-42AF-B342-76C7D8DE0252");
        
        PathString pathString = path;
        
        var isGreater = pathString >= pathString.ParentDirectory;
        
        var isEquals = Directory.GetParent(path)!.FullName >= pathString.ParentDirectory;
        Assert.Multiple(() =>
        {
            Assert.That(isGreater, Is.True);
            Assert.That(isEquals, Is.True);
        });
    }
}