using UnityEngine;

namespace ObserverPattern
{
    public class ClientController : MonoBehaviour
    {
        private BikeController bikeController;

        void Start() =>
            bikeController = (BikeController)FindAnyObjectByType<BikeController>();
        
        void OnGUI()
        {
            if (GUILayout.Button("Damage Bike"))
                if (bikeController) bikeController.TakeDamage(15f);

            if (GUILayout.Button("Toggle Turbo"))
                if (bikeController) bikeController.ToggleTurbo();
        }
    }
}