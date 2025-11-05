using UnityEngine;

namespace ServiceLocatorPattern
{
    public class Advertisement : IAdvertisement
    {
        public void DisplayAd()
        {
            Debug.Log("Displaying video advertisement");
        }
    }
}