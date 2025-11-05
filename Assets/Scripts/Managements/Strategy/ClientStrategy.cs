using System.Collections.Generic;
using UnityEngine;

namespace Strategy
{
    public class ClientStrategy : MonoBehaviour
    {
        private GameObject drone;
        private List<IManeuverBehaviour> components = new List<IManeuverBehaviour>();

        private void SpawnDrone()
        {
            drone = GameObject.CreatePrimitive(PrimitiveType.Cube);

            drone.AddComponent<Drone>();
            drone.transform.position = Random.insideUnitSphere * 10f;
            ApplyRandomStrategies();
        }
        private void ApplyRandomStrategies()
        {
            components.Add(drone.AddComponent<BoppingManeuver>());
            components.Add(drone.AddComponent<WeavingManeuver>());
            components.Add(drone.AddComponent<FallbackManeuver>());

            int index = Random.Range(0, components.Count);
            drone.GetComponent<Drone>().ApplyStrategy(components[index]);
        }
        void OnGUI()
        {
            if(GUILayout.Button("Spawn Drone"))
            {
                SpawnDrone();
            }
        }
    }
}