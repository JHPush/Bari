using UnityEngine;

namespace EventBus
{
    public class HUDController : MonoBehaviour
    {
        private bool isDisplayOn;

        void OnEnable() =>
            RaceEventBus.Subscribe(RaceEventType.START, DisplayHud);

        void OnDisable() =>
            RaceEventBus.UnSubscribe(RaceEventType.START, DisplayHud);

        private void DisplayHud() =>
            isDisplayOn = true;


        void OnGUI()
        {
            if (isDisplayOn)
                if (GUILayout.Button("Stop Race"))
                {
                    isDisplayOn = false;
                    RaceEventBus.Publish(RaceEventType.STOP);
                }
        }
    }
}