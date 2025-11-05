using System.Collections;
using UnityEngine;

namespace Strategy
{
    public class FallbackManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone) =>
            StartCoroutine(Fallback(drone));

        IEnumerator Fallback(Drone drone)
        {
            float time = 0;
            float spd = drone.spd;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPostion = startPosition;
            endPostion.z = drone.fallbackDistance;

            while(time < spd)
            {
                drone.transform.position = Vector3.Lerp(startPosition, endPostion, time / spd);
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}