namespace FitsFileRenamer.Services;

public interface IFileService {
    IEnumerable<string> ReadAllFiles(string path, SearchOption searchOption = SearchOption.AllDirectories);
}

public class FileService : IFileService {
    public IEnumerable<string> ReadAllFiles(string path, SearchOption searchOption = SearchOption.AllDirectories) {
        return Directory.GetFiles(path, "*.fits", SearchOption.AllDirectories);
    }
}