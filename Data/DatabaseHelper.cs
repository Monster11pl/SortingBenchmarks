namespace Data;

public class DatabaseHelper
{
    public static string GetDataProjectDataSource()
    {
        // Zakładamy, że program uruchamiany jest z bin/... więc cofamy się do katalogu głównego solution
        var baseDir = AppContext.BaseDirectory;

        // Cofnij się z bin/Debug/netX.Y do root i wejdź do Data/
        var dataDir = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\..\Data"));

        Directory.CreateDirectory(dataDir); // Na wypadek gdyby Data/ nie istniało

        return $"Data Source={dataDir}";
    }
}