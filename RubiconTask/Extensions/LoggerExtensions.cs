namespace RubiconTask.Extensions
{
  public static class LoggerExtensions
  {
    public static void DebugMethodStart(this ILogger logger, string? methodName)
    {
      if (logger == null)
      {
        return;
      }

      string message = $"{methodName} start.";
      logger.LogDebug(message);
    }

    public static void DebugMethodEnd(this ILogger logger, string? methodName)
    {
      if (logger == null)
      {
        return;
      }

      string message = $"{methodName} end.";
      logger.LogDebug(message);
    }

  }
}
