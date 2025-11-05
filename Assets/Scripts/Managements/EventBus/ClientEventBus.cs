using UnityEngine;

namespace EventBus
{
    public class ClientEventBus : MonoBehaviour
    {
        private bool isButtonEnabled;

        void Start()
        {
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountDownTimer>();
            gameObject.AddComponent<BikeController>();
            isButtonEnabled = true;
        }

        void OnEnable() =>
            RaceEventBus.Subscribe(RaceEventType.STOP, Restart);

        void OnDisable() =>
            RaceEventBus.UnSubscribe(RaceEventType.STOP, Restart);

        private void Restart() =>
            isButtonEnabled = true;

        void OnGUI()
        {
            if(isButtonEnabled)
            if(GUILayout.Button("Start CountDown"))
                {
                    isButtonEnabled = false;
                    RaceEventBus.Publish(RaceEventType.COUNTDOWN);
                }
        }

    }
}