// PathString Sample

// Get user's home directory

using AdvancedPath;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

// Create a PathString from a string

PathString path = home; // Implicit cast
// Or
PathString path2 = (PathString)home; // Explicit cast
// Or
PathString path3 = new PathString(home);
// Or
PathString path4 = home.ToPathString();

// Get the full path

string fullPath = path.FullPath;

// Get the file or directory name

string name = path.Name;

// Get the parent directory

PathString parent = path.ParentDirectory;
// Or
DirectoryPathString parent2 = path.ParentDirectory;
// Or
PathString parent3 = --path;
// Or
var directoryPathString = path.ToDirectoryPathString();
DirectoryPathString parent4 = --directoryPathString;

// Get the root directory

PathString root = path.RootDirectory;

// Get the existence of the path

bool exists = path.Exists;

// Create if not exists

path.CreateIfNotExists();

// Delete if exists

path.DeleteIfExists();

// Get the relative path

PathString relativePath = path.GetRelativePath(home);

// Combine paths

PathString combinedPath = path + "test.txt";

// If exists

if (path)
{
    // Do something
}

// If not exists

if (!path)
{
    // Do something
}

// Is a child of a path

var isChild = path > parent;

// Is a parent of a path

var isParent = path < parent;

// DirectoryPathString Sample

// Create a DirectoryPathString from a string

DirectoryPathString directoryPath = home; // Implicit cast
// Or
DirectoryPathString directoryPath2 = (DirectoryPathString)home; // Explicit cast
// Or
DirectoryPathString directoryPath3 = new DirectoryPathString(home);
// Or
DirectoryPathString directoryPath4 = home.ToDirectoryPathString();
// Or
DirectoryPathString directoryPath5 = path.ToDirectoryPathString();

// From director info

DirectoryInfo directoryInfo = new DirectoryInfo(home);
DirectoryPathString directoryPath6 = directoryInfo; // Implicit cast

// FilePathsString Sample

// Create a FilePathString from a string

FilePathString filePath = home; // Implicit cast
// Or
FilePathString filePath2 = (FilePathString)home; // Explicit cast
// Or
FilePathString filePath3 = new FilePathString(home);
// Or
FilePathString filePath4 = home.ToFilePathString();
// Or
FilePathString filePath5 = path.ToFilePathString();

// From file info

FileInfo fileInfo = new FileInfo(home);
FilePathString filePath6 = fileInfo; // Implicit cast

// Get the file extension

string extension = filePath.Extension;

// Get the file name without extension

string fileNameWithoutExtension = filePath.FileNameWithoutExtension;

// Get the file name

string fileName = filePath.FileName;

// Combine paths

FilePathString fileCombinedPath = home + "test.txt";