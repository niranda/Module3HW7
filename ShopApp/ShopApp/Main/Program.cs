using Microsoft.Extensions.DependencyInjection;
using ShopApp.Services.Abstractions;
using ShopApp.Providers.Abstractions;
using ShopApp.Providers;
using ShopApp.Services;

namespace StyleCop.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ILoggerProvider, LoggerProvider>()
                .AddTransient<IActionsService, ActionsService>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            start.Run();
        }
    }
}
