using System;
using System.Threading.Tasks;
using ShopApp.Models;

namespace ShopApp.Services.Abstractions
{
    public interface ILoggerService
    {
        event Func<string[], Task> Notify;
        void AddInfo(LogTypes logType, string msg);
        string[] GetLogArray();
        bool IsBackUpReady();
    }
}
