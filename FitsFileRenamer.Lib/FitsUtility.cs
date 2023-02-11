using FitsFileRenamer.Common;
using JPFITS;

namespace FitsFileRename.Lib;

public static class FitsUtility {

    public static IEnumerable<FitsFileDto> LoadMetadata(IEnumerable<string> paths) {
       var fitsImages = paths.Select(f => new FITSImage(f, true));
       return fitsImages.Select(fitsImage => new FitsFileDto {
               FullPathName = fitsImage.FullFileName,
               Date = DateTime.Parse(fitsImage.Header.GetKeyValue("DATE-LOC")),
               UtcDate = DateTime.Parse(fitsImage.Header.GetKeyValue("DATE-OBS")),
               Exposure = double.Parse(fitsImage.Header.GetKeyValue("EXPOSURE")),
               Filter = fitsImage.Header.GetKeyValue("FILTER"),
               Gain = int.Parse(fitsImage.Header.GetKeyValue("GAIN")),
               SetTemperature = double.Parse(fitsImage.Header.GetKeyValue("SET-TEMP")),
               ActualTemperature = double.Parse(fitsImage.Header.GetKeyValue("CCD-TEMP")),
               ImageType = fitsImage.Header.GetKeyValue("IMAGETYP")
           })
           .ToList();
    }
}