using ShopApp.Configs;

namespace ShopApp.Services.Abstractions
{
    public interface IConfigService
    {
        Config DeserializeConfig();
    }
}
