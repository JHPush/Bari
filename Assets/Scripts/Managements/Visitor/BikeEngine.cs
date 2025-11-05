using UnityEngine;

namespace Visitor
{
    public class BikeEngine : MonoBehaviour, IBikeElement
    {
        public float turboBoost = 25f;
        public float maxTurboBoost = 200f;

        private bool isTurboOn;
        private float defaultSpd = 300f;
        
        public float CurrentSpd
        {
            get
            {
                if (isTurboOn) return defaultSpd + turboBoost;
                return defaultSpd;
            }
        }
        public void ToggleTurbo() =>
            isTurboOn = !isTurboOn;

        public void Accept(IVIsitor visitor) =>
            visitor.Visit(this);
        
        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 20, 200, 20), "Turbo Boost : " + turboBoost);
        }
    }
}