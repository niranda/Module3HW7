using ShopApp.Providers.Abstractions;

namespace ShopApp.Providers
{
    public class LoggerProvider : ILoggerProvider
    {
        public LoggerProvider()
        {
            LogArray = new string[100];
        }

        public string[] LogArray { get; set; }
    }
}
