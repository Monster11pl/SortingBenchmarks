using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class BenchmarkHardwareInfoRepository(BenchmarkDbContext context) : IBenchmarkHardwareInfoRepository
{
    public int AddIfNotExists(BenchmarkHardwareInfo hwInfo)
    {
        var dbHwInfo = context.BenchmarkHardwareInfos
            .SingleOrDefault(x => 
                x.OsUser == hwInfo.OsUser
                && x.Os ==  hwInfo.Os
                && x.SystemArchitecture == hwInfo.SystemArchitecture
                && x.ProcessorName == hwInfo.ProcessorName
                && x.CoresCount == hwInfo.CoresCount
                && x.ThreadsCount == hwInfo.ThreadsCount
                && x.MaxClockSpeed == hwInfo.MaxClockSpeed);

        if (dbHwInfo == null)
        {
            context.BenchmarkHardwareInfos.Add(hwInfo);
            context.SaveChanges();
            return hwInfo.Id;
        }
        
        return dbHwInfo.Id;
    }
}