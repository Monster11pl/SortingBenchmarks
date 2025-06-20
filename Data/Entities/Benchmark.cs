using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Benchmark
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string SortAlgorithm { get; set; } = string.Empty;
    
    [Required]
    public int Elements { get; set; }
    
    [Required]
    public TimeSpan ExecutionTime { get; set; }
    
    [Required]
    public int ThreadsUsed { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    
    [Required]
    public int BenchmarkHardwareInfoId { get; set; } // FK
    [Required]
    public required BenchmarkHardwareInfo BenchmarkHardwareInfo { get; set; } // Navigation
    
}