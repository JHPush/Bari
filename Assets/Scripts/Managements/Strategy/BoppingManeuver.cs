using System.Collections;
using UnityEngine;

namespace Strategy
{
    public class BoppingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone) =>
            StartCoroutine(Bopple(drone));
        
        IEnumerator Bopple(Drone drone)
        {
            float time;
            bool isReverse = false;
            float spd = drone.spd;

            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.y = drone.maxHeight;

            while (true)
            {
                time = 0;
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