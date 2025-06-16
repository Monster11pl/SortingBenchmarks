using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Benchmark
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string SortAlgorithm { get; set; } = string.Empty;
    
    public int Elements { get; set; }
    public TimeSpan ExecutionTime { get; set; }
    public string? Cpu { get; set; }
    public int ThreadsUsed { get; set; }
    public DateTime Date { get; set; }
    
}