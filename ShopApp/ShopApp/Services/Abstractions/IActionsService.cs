namespace ShopApp.Services.Abstractions
{
    public interface IActionsService
    {
        void CreateInfoLog();
        void CreateWarningLog();
        void CreateErrorLog();
    }
}
