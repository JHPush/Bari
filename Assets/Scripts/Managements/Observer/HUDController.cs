using UnityEngine;

namespace ObserverPattern
{
    public class HUDController : Observer
    {
        private bool IsTurboOn;
        private float currentHealth;
        private BikeController bikeController;

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health : " + currentHealth);
            GUILayout.EndHorizontal();

            if (IsTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated");
                GUILayout.EndHorizontal();
            }
            if (currentHealth <= 50f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("WARNING: LowHealth");
                GUILayout.EndHorizontal();
            }
            GUILayout.EndArea();
        }
        public override void Notify(Subject subject)
        {
            if (!bikeController)
                bikeController = subject.GetComponent<BikeController>();

            if (bikeController)
            {
                IsTurboOn = bikeController.IsTurboOn;
                currentHealth = bikeController.CurrentHealth;
            }
        }
    }
}