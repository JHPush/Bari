using UnityEngine;
namespace ObserverPattern
{
    public class CameraController : Observer
    {
        private bool IsTurboOn;
        private Vector3 initPosition;
        private float shakeMagnitude = .1f;
        private BikeController bikeController;

        void OnEnable() =>
            initPosition = gameObject.transform.localPosition;

        void Update()
        {
            if (!IsTurboOn)
            {
                gameObject.transform.localPosition = initPosition;
                return;
            }
            gameObject.transform.localPosition = initPosition + (Random.insideUnitSphere * shakeMagnitude);
        }
        public override void Notify(Subject subject)
        {
            if (!bikeController)
                bikeController = subject.GetComponent<BikeController>();

            if (bikeController)
                IsTurboOn = bikeController.IsTurboOn;
        }
    }
}