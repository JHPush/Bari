using UnityEngine;

namespace Facade
{
    public class ClientFacade : MonoBehaviour
    {
        private BikeEngine bikeEngine;

        void Start() => bikeEngine = gameObject.AddComponent<BikeEngine>();

        void OnGUI()
        {
            if (GUILayout.Button("Turn On")) bikeEngine.TurnOn();
            if (GUILayout.Button("Turn Off")) bikeEngine.TurnOff();
            if (GUILayout.Button("Toggle Turbo")) bikeEngine.ToggleTurbo();
        }
    }
}