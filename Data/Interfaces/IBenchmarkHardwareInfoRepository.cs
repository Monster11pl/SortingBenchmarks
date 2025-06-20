using Data.Entities;

namespace Data.Interfaces;

public interface IBenchmarkHardwareInfoRepository
{
    int AddIfNotExists(BenchmarkHardwareInfo hwInfo);
}