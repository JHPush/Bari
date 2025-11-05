using System.Collections;
using UnityEngine;

namespace Strategy
{
    public class WeavingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone) =>
            StartCoroutine(Weave(drone));

        IEnumerator Weave(Drone drone)
        {
            float time;
            bool isReverse = false;
            float spd = drone.spd;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.x = drone.weavingDistance;

            while (true)
            {
                time = 0f;
                Vector3 start = drone.transform.position;
                Vector3 end = (isReverse) ? startPosition : endPosition;

                while (time < spd)
                {
                    drone.transform.position = Vector3.Lerp(start, end, time / spd);
                    time += Time.deltaTime;
                    yield return null;
                }
                yield return new WaitForSeconds(1);
                isReverse = !isReverse;
            }
        }
    }
}