namespace Test;

public class DirectoryPathStringTest
{
    private readonly string _userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    [Test]
    public void FromDirectoryInfo()
    {
        var directoryInfo = new DirectoryInfo(_userPath);
        DirectoryPathString directoryPathString = directoryInfo;
        Assert.That(directoryPathString.FullPath, Is.EqualTo(_userPath));
    }
}