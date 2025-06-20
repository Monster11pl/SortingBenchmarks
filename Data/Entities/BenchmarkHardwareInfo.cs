namespace Data.Entities;

public class BenchmarkHardwareInfo
{
    public int Id { get; set; }
    public string OsUser { get; set; }
    public string Os { get; set; }
    public string SystemArchitecture { get; set; }
    public string ProcessorName { get; set; }
    public int CoresCount { get; set; }
    public int ThreadsCount { get; set; }
    public int MaxClockSpeed { get; set; }
    
    public ICollection<Benchmark> Benchmarks { get; set; }
}