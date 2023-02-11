namespace FitsFileRenamer.Common;

public class FitsFileDto {
    public string? FullPathName { get; set; }
    public DateTime Date { get; set; }
    public DateTime UtcDate { get; set; }
    public string Filter { get; set; }
    public double SetTemperature { get; set; }
    public double ActualTemperature { get; set; }
    public double Exposure { get; set; }
    public int Gain { get; set; }
    public string ImageType { get; set; }
}