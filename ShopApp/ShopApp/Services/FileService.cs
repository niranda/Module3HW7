using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ShopApp.Services.Abstractions;
using ShopApp.Configs;

namespace ShopApp.Services
{
    public class FileService : IFileService
    {
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly FileServiceConfig _fileServiceConfig;
        private readonly Config _config;
        private readonly string _directoryPath;
        private int _i;

        public FileService(IConfigService config)
        {
            _config = config.DeserializeConfig();
            _fileServiceConfig = _config.FileService;
            _directoryPath = _fileServiceConfig.DirectoryPath;
            _semaphoreSlim = new SemaphoreSlim(1);
            _i = 0;
        }

        public void InitFileSystem()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        public async Task WriteAsync(string[] logArray)
        {
            var currentTime = DateTime.UtcNow;
            var streamWriter = new StreamWriter($"{_directoryPath}/{currentTime.ToString("HH.mm.ss")} {_i} {currentTime.ToString("dd.MM.yyyy")}.txt");
            await _semaphoreSlim.WaitAsync();
            await streamWriter.WriteAsync(string.Join(string.Empty, logArray));
            await streamWriter.FlushAsync();
            _i++;
            _semaphoreSlim.Release();
        }
    }
}
