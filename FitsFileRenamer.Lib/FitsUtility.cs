using FitsFileRenamer.Common;
using FitsLibrary;

namespace FitsFileRename.Lib;

public static class FitsUtility {
    public static async Task<IEnumerable<FitsFileDto>> LoadMetadata(IEnumerable<string> paths) {
        var reader = new FitsDocumentReader();

        var dtos = new List<FitsFileDto>();
        foreach (var path in paths) {
            var fits = await reader.ReadAsync(path);
            var dto = new FitsFileDto {
                FullPathName = path,
                Filter = fits.Header["FILTER"] as string ?? string.Empty,
                ImageType = fits.Header["IMAGETYP"] as string ?? string.Empty,
            };

            if (DateTime.TryParse(fits.Header["DATE-LOC"] as string, out var dateLoc)) {
                dto.Date = dateLoc;
            }
            
            if (DateTime.TryParse(fits.Header["DATE-OBS"] as string, out var dateObs)) {
                dto.DateUtc = dateObs;
            }
            
            if (double.TryParse(fits.Header["EXPOSURE"]?.ToString(), out var exposure)) {
                dto.Exposure = exposure;
            }

            if (int.TryParse(fits.Header["GAIN"]?.ToString(), out var gain)) {
                dto.Gain = gain;
            }
            
            if (double.TryParse(fits.Header["SET-TEMP"]?.ToString(), out var setTemperature)) {
                dto.SetTemperature = setTemperature;
            }
            
            if (double.TryParse(fits.Header["CCD-TEMP"]?.ToString(), out var actualTemperature)) {
                dto.ActualTemperature = actualTemperature;
            }

            dtos.Add(dto);
        }

        return dtos;
    }
}