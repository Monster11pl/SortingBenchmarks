using System.Runtime.InteropServices;
using Application.Models;
using Hardware.Info;

namespace Application.Helpers;

public class MachineInfoHelper
{
    public static BenchmarkHardwareInfoDto GetHardwareInfo()
    {
        var hardwareInfo = new HardwareInfo();
        hardwareInfo.RefreshCPUList();

        var currentCpu = hardwareInfo.CpuList.FirstOrDefault();
        if(currentCpu == null)
            throw new Exception("CPU not found");
        
        var benchHwInfo = new BenchmarkHardwareInfoDto
        {
            OsUser = Environment.UserDomainName + "\\" + Environment.UserName,
            Os = RuntimeInformation.OSDescription,
            SystemArchitecture = RuntimeInformation.OSArchitecture.ToString(),
            ProcessorName = currentCpu.Name,
            CoresCount = (int)currentCpu.NumberOfCores,
            ThreadsCount = (int)currentCpu.NumberOfLogicalProcessors,
            MaxClockSpeed = (int)currentCpu.MaxClockSpeed
        };
        
        return benchHwInfo;
    }
}