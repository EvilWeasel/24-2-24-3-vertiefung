namespace polymorphism_logging;
public class Logger
{
  public string Logprefix { get; set; } = "Info";
  public void Log(string message)
  {
    Console.WriteLine(
      Logprefix + ": " + message
    );
  }
}

public class TextFileLogger()
{

}
