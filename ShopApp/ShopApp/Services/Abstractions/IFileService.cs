using System.Threading.Tasks;

namespace ShopApp.Services.Abstractions
{
    public interface IFileService
    {
        void InitFileSystem();
        Task WriteAsync(string[] logArray);
    }
}
