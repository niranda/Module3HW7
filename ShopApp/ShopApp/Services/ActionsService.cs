using ShopApp.Services.Abstractions;
using ShopApp.Models;

namespace ShopApp.Services
{
    public class ActionsService : IActionsService
    {
        private readonly ILoggerService _logger;

        public ActionsService(ILoggerService logger)
        {
            _logger = logger;
        }

        public void CreateInfoLog()
        {
           _logger.AddInfo(LogTypes.Info, "Start method: CreateInfoLog");
        }

        public void CreateWarningLog()
        {
            _logger.AddInfo(LogTypes.Warning, "Start method: CreateWarningLog");
        }

        public void CreateErrorLog()
        {
            _logger.AddInfo(LogTypes.Error, "Start method: CreateErrorLog");
        }
    }
}
