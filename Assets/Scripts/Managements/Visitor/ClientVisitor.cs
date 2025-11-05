using UnityEngine;

namespace Visitor
{
    public class ClientVisitor : MonoBehaviour
    {
        public PowerUp enginePowerUp;
        public PowerUp shiledPowerUp;
        public PowerUp weaponPowerUp;

        private BikeController bikeController;

        void Start()
        {
            bikeController = gameObject.AddComponent<BikeController>();
        }

        void OnGUI()
        {
            if (GUILayout.Button("PowerUp Shield"))
                bikeController.Accept(shiledPowerUp);
            if (GUILayout.Button("PowerUp Weapon"))
                bikeController.Accept(weaponPowerUp);
            if (GUILayout.Button("PowerUp Engine"))
                bikeController.Accept(enginePowerUp);
        }
    }
}