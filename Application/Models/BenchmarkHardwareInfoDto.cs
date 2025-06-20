using System.Text;

namespace Application.Models;

public class BenchmarkHardwareInfoDto
{
    public string OsUser { get; set; }
    public string Os { get; set; }
    public string SystemArchitecture { get; set; }
    public string ProcessorName { get; set; }
    public int CoresCount { get; set; }
    public int ThreadsCount { get; set; }
    public int MaxClockSpeed { get; set; }

    private double MaxClockSpeedGhzRounded => Math.Round(MaxClockSpeed / 1000.0, 2);
    
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("------------------------------------------------");
        sb.AppendLine("Benchmark System Info:");
        sb.AppendLine($"USER: {OsUser}:");
        sb.AppendLine($"OS: {Os} ({SystemArchitecture})");
        sb.AppendLine($"Processor: {ProcessorName.TrimEnd()} [{CoresCount}C/{ThreadsCount}T @{MaxClockSpeedGhzRounded}GHz]");
        sb.AppendLine("------------------------------------------------");
        
        return sb.ToString();
    }
}