namespace Basic_Programming_Principles.DesignPatterns
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
    }

    // This is the old legacy logger that doesn't follow the new ILogger interface
    public class LegacyLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine($"Legacy Log: {message}");
        }

        public void WriteErrorLog(string error)
        {
            Console.WriteLine($"Legacy Error Log: {error}");
        }
    }

    public class Application
    {
        private readonly ILogger _logger;

        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInfo("Application is running.");
            _logger.LogError("Something went wrong!");
        }
    }

    public class LoggerAdapter : ILogger
    {
        private readonly LegacyLogger _legacyLogger;

        public LoggerAdapter()
        {
            _legacyLogger = new LegacyLogger();
        }

        public void LogError(string message)
        {
            _legacyLogger.WriteErrorLog(message);
        }

        public void LogInfo(string message)
        {
            _legacyLogger.WriteLog(message);
        }
    }

    class AdapterDemo
    {
        public static void Execute()
        {
            // Create a new instance of the legacy logger
            ILogger logger = new LoggerAdapter();
            var application = new Application(logger);
        }
    }

}
