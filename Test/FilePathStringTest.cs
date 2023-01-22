namespace Test;

public class FilePathStringTest
{
    private static readonly string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    private readonly string _filePath = Path.Combine(UserPath, "test.txt");

    [Test]
    public void FileName()
    {
        FilePathString filePath = _filePath;
        Assert.That(filePath.FileName, Is.EqualTo("test.txt"));
    }
    
    [Test]
    public void FileNameWithoutExtension()
    {
        FilePathString filePath = _filePath;
        Assert.That(filePath.FileNameWithoutExtension, Is.EqualTo("test"));
    }
    
    [Test]
    public void Extension()
    {
        FilePathString filePath = _filePath;
        Assert.That(filePath.Extension, Is.EqualTo(".txt"));
    }
    
    [Test]
    public void FromFileInfo()
    {
        var fileInfo = new FileInfo(_filePath);
        FilePathString filePath = fileInfo;
        Assert.That(filePath.FullPath, Is.EqualTo(_filePath));
    }

    [Test]
    public void PlusOperator()
    {
        FilePathString filePath = _filePath;
        filePath += "test2.txt";
        Assert.That(filePath.FullPath, Is.EqualTo(Path.Combine(UserPath, "test.txt", "test2.txt")));
    }
}