using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBus
{
    public enum RaceEventType
    {
        COUNTDOWN, START, RESTART, STOP, PAUSE, FINISH, QUIT
    }
    public class RaceEventBus : MonoBehaviour
    {
        private static readonly IDictionary<RaceEventType, UnityEvent>
            events = new Dictionary<RaceEventType, UnityEvent>();
        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;
            if (events.TryGetValue(eventType, out thisEvent))
                thisEvent.AddListener(listener);
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                events.Add(eventType, thisEvent);
            }

        }
        public static void UnSubscribe(RaceEventType type, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (events.TryGetValue(type, out thisEvent))
                thisEvent.RemoveListener(listener);
        }
        
        public static void Publish(RaceEventType type)
        {
            UnityEvent thisEvent;
            if (events.TryGetValue(type, out thisEvent))
                thisEvent.Invoke();
        }
    }

}
