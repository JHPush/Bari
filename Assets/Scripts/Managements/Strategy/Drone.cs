using UnityEngine;

namespace Strategy
{
    public class Drone : MonoBehaviour
    {
        private RaycastHit _hit;
        private Vector3 rayDirection;
        private float rayAngle = -45f;
        private float rayDistance = 15f;


        public float spd = 1f;
        public float maxHeight = 5f;
        public float weavingDistance = 1.5f;
        public float fallbackDistance = 20f;

        void Start()
        {
            rayDirection = transform.TransformDirection(Vector3.back) * rayDistance;
            rayDirection = Quaternion.Euler(rayAngle, 0f, 0f) * rayDirection;
        }
        public void ApplyStrategy(IManeuverBehaviour strategy) =>
            strategy.Maneuver(this);

        void Update()
        {
            Debug.DrawRay(transform.position, rayDirection, Color.blue);
            if(Physics.Raycast(transform.position, rayDirection, out _hit, rayDistance))
            {
                if (_hit.collider)
                    Debug.DrawRay(transform.position, rayDirection, Color.red);
            }
        }
    }
}