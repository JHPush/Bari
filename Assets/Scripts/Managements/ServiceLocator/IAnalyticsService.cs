namespace ServiceLocatorPattern
{
    public interface IAnalyticsService
    {
        void SendEvent(string eventName);
    }
}