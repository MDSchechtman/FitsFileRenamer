using FitsFileRename.Lib;
using FitsFileRenamer.Common;

namespace FitsFileRenamer.Services;

public interface IFitsService {
    Task<IEnumerable<FitsFileDto>> OpenDirectory(string rootPath);
}

public class FitsService : IFitsService {
    private readonly IFileService _fileService;

    public FitsService(IFileService fileService) {
        _fileService = fileService;
    }
    public async Task<IEnumerable<FitsFileDto>> OpenDirectory(string rootPath) {
        var paths = _fileService.ReadAllFiles(rootPath);
        return await FitsUtility.LoadMetadata(paths);
    }
}