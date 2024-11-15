using FileHandlerApp;
using System.IO;
using FileHandlerApp.Exceptions;

public class FileHandler
{
    private readonly string _filePath;

    public FileHandler(string filePath)
    {
        _filePath = filePath;
        EnsureFileExists();
    }

    private void EnsureFileExists()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
        if (!File.Exists(_filePath))
            File.Create(_filePath).Close();
    }

    public void SaveUser(User user)
    {
        File.AppendAllText(_filePath, user.ToString() + Environment.NewLine);
    }

    public string LoadUsers()
    {
        try
        {
            return File.ReadAllText(_filePath);
        }
        catch
        {
            throw new FileLoadException("Kunne ikke læse filen.");
        }
    }
}
