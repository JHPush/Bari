using UnityEngine;

namespace Visitor
{
    public class PickUp : MonoBehaviour
    {
        public PowerUp powerUp;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.GetComponent<BikeController>()) return;
            other.GetComponent<BikeController>().Accept(powerUp);
            Destroy(gameObject);

        }
    }
}