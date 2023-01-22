// See https://aka.ms/new-console-template for more information

// PathString Sample

// Get user's home directory

using AdvancedPath;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

// Create a PathString from a string

PathString path = new PathString(home);
// Or
PathString orPath = home;

// Get the path as a string

string pathString = path.ToString();

// Get PathString's Parent

DirectoryPathString parent = path.ParentDirectory;

// PathString Operations

// Combine two paths

PathString combinedPath = path + "Documents";

// Get the path's extension

string extension = path.ToFilePathString().Extension;

// Get the path's filename

string filename = path.ToFilePathString().FileName;

// Get the path's filename without extension

string filenameWithoutExtension = path.ToFilePathString().FileNameWithoutExtension;

// Get the path's directory name

string directoryName = path.ParentDirectory.Name;

// DirectoryPathString Sample

// Create a DirectoryPathString from a string

DirectoryPathString directoryPath = new DirectoryPathString(home);

// Get the path as a string

string directoryPathString = directoryPath;

// Get DirectoryPathString's Parent

DirectoryPathString parentDirectory = directoryPath.ParentDirectory;

// DirectoryPathString Operations

// Combine two paths

PathString combinedDirectoryPath = directoryPath + "Documents";

// Get the path's directory name

string directoryName2 = directoryPath.Name;

// FilePathString Sample

// Create a FilePathString from a string

FilePathString filePath = new FilePathString(home + "\\Documents\\test.txt");

// Get the path as a string

string filePathString = filePath;

// Get FilePathString's Parent

DirectoryPathString parentDirectory2 = filePath.ParentDirectory;

// FilePathString Operations

// Combine two paths

PathString combinedFilePath = filePath + "test2.txt";

// Get the path's extension

string extension2 = filePath.Extension;

// Get the path's filename

string filename2 = filePath.FileName;

// Get the path's filename without extension

string filenameWithoutExtension2 = filePath.FileNameWithoutExtension;

// Get the path's directory name

string directoryName3 = filePath.ParentDirectory.Name;
