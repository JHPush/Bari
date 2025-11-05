using UnityEngine;

namespace ObserverPattern
{
    public class BikeController : Subject
    {
        public bool IsTurboOn { get; private set; }
        public float CurrentHealth { get { return health; } }

        private bool isEngineOn;
        private HUDController hudController;
        private CameraController cameraController;


        [SerializeField]
        private float health = 100f;

        void Awake()
        {
            hudController = gameObject.AddComponent<HUDController>();
            cameraController = (CameraController)FindAnyObjectByType(typeof(CameraController));
        }
        private void Start() =>
            StartEngine();

        void OnEnable()
        {
            if (hudController) Attach(hudController);
            if (cameraController) Attach(cameraController);
        }
        void OnDisable()
        {
            if (hudController) Detach(hudController);
            if (cameraController) Detach(cameraController);
        }

        private void StartEngine()
        {
            isEngineOn = true;
            NotifyObservers();
        }
        public void ToggleTurbo()
        {
            if (isEngineOn) IsTurboOn = !IsTurboOn;
            NotifyObservers();
        }
        public void TakeDamage(float amount)
        {
            health -= amount;
            IsTurboOn = false;

            NotifyObservers();

            if (health < 0) Destroy(gameObject);
        }
    }
}