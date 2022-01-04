using System;
using System.Threading.Tasks;
using ShopApp.Models;
using ShopApp.Services.Abstractions;
using ShopApp.Providers.Abstractions;
using ShopApp.Configs;

namespace ShopApp.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly LoggerServiceConfig _loggerServiceConfig;
        private readonly Config _config;
        private readonly int _backupNumber;
        private int _arrayCounter;
        private ILoggerProvider _loggerProvider;

        public LoggerService(ILoggerProvider loggerProvider, IConfigService config)
        {
            _config = config.DeserializeConfig();
            _loggerServiceConfig = _config.LoggerService;
            _backupNumber = _loggerServiceConfig.BackupNumber;
            _loggerProvider = loggerProvider;
            _arrayCounter = 0;
        }

        public event Func<string[], Task> Notify;

        public string[] GetLogArray()
        {
            return _loggerProvider.LogArray;
        }

        public void AddInfo(LogTypes logType, string msg)
        {
            var log = $"{DateTime.UtcNow.ToLongTimeString()}: {logType}: {msg}";
            Console.WriteLine(log);
            _loggerProvider.LogArray[_arrayCounter] = log;
            if (IsBackUpReady())
            {
                Notify?.Invoke(_loggerProvider.LogArray);
            }

            _arrayCounter++;
        }

        public bool IsBackUpReady()
        {
            if ((_arrayCounter + 1) % _backupNumber == 0)
            {
                return true;
            }

            return false;
        }
    }
}
