using System.Text.Json;

namespace polymorphism_logging;

public abstract class Logger
{
    public string Originprefix { get; set; }
    public abstract void Log(string message);
}

public interface IFileLogger
{
    public string FilePath { get; set; }
}

public class ConsoleLogger : Logger
{
    public ConsoleLogger(string kunde)
    {
        Originprefix = kunde;
    }
    public override void Log(string message)
    {
        Console.WriteLine(
          Originprefix + ": " + message
        );
    }
}

public class TextFileLogger : Logger, IFileLogger
{
    public string FilePath { get; set; }
    public TextFileLogger(string kunde)
    {
        Originprefix = kunde;
        FilePath = "logger.txt";
    }

    public override void Log(string message)
    {
        File.AppendAllText(FilePath,
        Originprefix + ": " + message + "\n");
    }
}

public class JSONFileLogger : Logger, IFileLogger
{
    public string FilePath { get; set; }
    public JSONFileLogger(string kunde)
    {
        Originprefix = kunde;
        FilePath = "logger.json";
    }
    public override void Log(string message)
    {
        File.AppendAllText(FilePath,
          JsonSerializer.Serialize(message)
        );
    }
}
