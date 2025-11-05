using System.Collections;
using UnityEngine;

namespace Facade
{
    public class TurboCharger : MonoBehaviour
    {
        public BikeEngine engine;
        private bool isTurboOn;
        private CoolingSystem coolingSystem;

        public void ToggleTurbo(CoolingSystem coolingSystem)
        {
            this.coolingSystem = coolingSystem;
            if (!isTurboOn) StartCoroutine(TurboCharge());
        }

        IEnumerator TurboCharge()
        {
            isTurboOn = true;
            coolingSystem.PauseCoolinng();

            yield return new WaitForSeconds(engine.turboDuration);
            isTurboOn = false;
            coolingSystem.PauseCoolinng();
        }
        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(100, 60, 500, 20), "Turbo Activated : " + isTurboOn);
        }
    }
}