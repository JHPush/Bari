using UnityEngine;

namespace Visitor
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public float health = 50f;

        public float Demage(float amount)
        {
            health -= amount;
            return health;
        }
        public void Accept(IVIsitor visitor) =>
            visitor.Visit(this);

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 0, 200, 20), "Shiled Health : " + health);
        }
    }
}