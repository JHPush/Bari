
using System.Collections;
using UnityEngine;

namespace EventBus
{
    public class CountDownTimer : MonoBehaviour
    {
        private float currentTime;
        private float duration = 3f;

        void OnEnable() =>
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);

        void OnDisable() =>
            RaceEventBus.UnSubscribe(RaceEventType.COUNTDOWN, StartTimer);

        private void StartTimer() =>
            StartCoroutine(CountDown());

        private IEnumerator CountDown()
        {
            currentTime = duration;
            while (currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                currentTime--;
            }
            RaceEventBus.Publish(RaceEventType.START);
        }
        
        void OnGUI()
        {
            GUI.color = Color.blue;
            GUI.Label(new Rect(125, 0, 100, 20), "CountDown : " + currentTime);
        }
    }
}