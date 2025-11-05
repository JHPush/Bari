using UnityEngine;

namespace ServiceLocatorPattern
{
    public class ClientServiceLocator : MonoBehaviour
    {
        void Start()
        {
            RegisterServices();
        }
        private void RegisterServices()
        {
            ILoggerService logger = new Logger();
            ServiceLocator.RegisterService(logger);

            IAnalyticsService analytics = new Analytics();
            ServiceLocator.RegisterService(analytics);

            IAdvertisement advertisement = new Advertisement();
            ServiceLocator.RegisterService(advertisement);
        }
        void OnGUI()
        {
            GUILayout.Label("Review output in the console");

            if (GUILayout.Button("Log Event"))
            {
                ILoggerService logger = ServiceLocator.GetService<ILoggerService>();
                logger.Log("Hello Logger");
            }
            if (GUILayout.Button("Send Analytics"))
            {
                IAnalyticsService logger = ServiceLocator.GetService<IAnalyticsService>();
                logger.SendEvent("Hello Logger");
            }
            if(GUILayout.Button("Display Advertisement"))
            {
                IAdvertisement logger = ServiceLocator.GetService<IAdvertisement>();
                logger.DisplayAd();
            }
        }
    }
}