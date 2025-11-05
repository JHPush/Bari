using UnityEngine;

namespace Facade
{
    public class BikeEngine : MonoBehaviour
    {
        public float burnRate = 1f;
        public float fuelAmount = 100f;
        public float tempRate = 5f;
        public float minTemp = 50f;
        public float maxTemp = 65f;
        public float currentTemp;
        public float turboDuration = 2f;

        private bool isEngineOn;
        private FuelPump fuelPump;
        private TurboCharger turboCharger;
        private CoolingSystem coolingSystem;
        void Awake()
        {
            fuelPump = gameObject.AddComponent<FuelPump>();
            turboCharger = gameObject.AddComponent<TurboCharger>();
            coolingSystem = gameObject.AddComponent<CoolingSystem>();
        }
        void Start()
        {
            fuelPump.engine = this;
            turboCharger.engine = this;
            coolingSystem.engine = this;
        }

        public void TurnOn()
        {
            isEngineOn = true;
            StartCoroutine(fuelPump.burnFeul);
            StartCoroutine(coolingSystem.coolEngine);
        }
        public void TurnOff()
        {
            isEngineOn = false;
            coolingSystem.ResetTemperature();
            StopCoroutine(fuelPump.burnFeul);
            StopCoroutine(coolingSystem.coolEngine);
        }
        public void ToggleTurbo()
        {
            if (isEngineOn) turboCharger.ToggleTurbo(coolingSystem);
        }
        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(100, 0, 500, 20), "Engine Running : " + isEngineOn);
        }
    }
}