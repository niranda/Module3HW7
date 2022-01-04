using System;
using System.Threading;
using System.Threading.Tasks;
using ShopApp.Services.Abstractions;

namespace StyleCop.Main
{
    public class Starter
    {
        private readonly IActionsService _actionsService;
        private readonly ILoggerService _loggerService;
        private readonly IFileService _fileService;
        private readonly SemaphoreSlim _semaphoreSlim;

        public Starter(IActionsService actionsService, ILoggerService loggerService, IFileService fileService)
        {
            _semaphoreSlim = new SemaphoreSlim(1);
            _actionsService = actionsService;
            _loggerService = loggerService;
            _fileService = fileService;
        }

        public void Run()
        {
            _fileService.InitFileSystem();
            _loggerService.Notify += _fileService.WriteAsync;

            Task.Run(() =>
            {
                for (var i = 0; i < 50; i++)
                {
                    Task.Run(async () => { await Randomizer(); });
                }
            });

            Task.Run(() =>
            {
                for (var i = 0; i < 50; i++)
                {
                    Task.Run(async () => { await Randomizer(); });
                }
            });

            Console.ReadKey();
        }

        public async Task Randomizer()
        {
            await _semaphoreSlim.WaitAsync();

            await Task.Run(() =>
            {
                var randomNum = new Random();
                var value = randomNum.Next(0, 3);
                switch (value)
                {
                    case 0:
                        _actionsService.CreateInfoLog();
                        break;
                    case 1:
                        _actionsService.CreateWarningLog();
                        break;
                    case 2:
                        _actionsService.CreateErrorLog();
                        break;
                }
            });

            _semaphoreSlim.Release();
        }
    }
}
